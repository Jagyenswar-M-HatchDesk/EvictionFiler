using EvictionFiler.Application.DTOs.TransactionDtos;
using EvictionFiler.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class CloverService : ICloverService
    {

        private readonly IHttpClientFactory _factory;
        private readonly IHttpContextAccessor _httpContext;

        public CloverService(IHttpClientFactory factory,
                             IHttpContextAccessor httpContext)
        {
            _factory = factory;
            _httpContext = httpContext;
        }

        public async Task<TransactionDto?> CreateChargeAsync(string token, int amount)
        {
            var accessToken = "83c4568f-2765-fe39-4000-d131280ac551";

            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            client.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());

            var clientIp = _httpContext.HttpContext?.Connection.RemoteIpAddress?.ToString();

            if (!string.IsNullOrEmpty(clientIp))
            {
                client.DefaultRequestHeaders.Add("X-Forwarded-For", clientIp);
            }

            var body = new
            {
                amount = amount,
                currency = "usd",
                source = token
            };

            var content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(
                "https://scl-sandbox.dev.clover.com/v1/charges",
                content);

            var json = await response.Content.ReadAsStringAsync();

            var cloverResponse = JsonSerializer.Deserialize<CloverChargeResponse>(json);

            if (cloverResponse == null)
                return null;

            return new TransactionDto
            {
                CloverChargeId = cloverResponse.id,
                Amount = cloverResponse.amount,
                Currency = cloverResponse.currency,
                Status = cloverResponse.status,
                Paid = cloverResponse.paid,
                Captured = cloverResponse.captured,
                ReferenceNumber = cloverResponse.ref_num,
                AuthorizationCode = cloverResponse.auth_code,
                CreatedUtc = DateTimeOffset
                    .FromUnixTimeMilliseconds(cloverResponse.created)
                    .UtcDateTime
               
            };
        }
    }
}
