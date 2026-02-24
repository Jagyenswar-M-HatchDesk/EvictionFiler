using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvictionFiler.Application.DTOs.CaptchaDto;
using Newtonsoft.Json;

namespace EvictionFiler.Application.Services
{
    public class CaptchaService
    {
        private readonly string _secretKey;

        public CaptchaService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public async Task<bool> ValidateRecaptcha(string captchaToken)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "https://www.google.com/recaptcha/api/siteverify",
                    new FormUrlEncodedContent(new[]
                    {
                new KeyValuePair<string, string>("secret", _secretKey),
                new KeyValuePair<string, string>("response", captchaToken)
                    }));

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<RecaptchaResponse>(jsonResponse);

                if (result == null || !result.success)
                    return false;

                return result.score >= 0.5;
            }
        }

    }
}
