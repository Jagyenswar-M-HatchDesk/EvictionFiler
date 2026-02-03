
using EvictionFiler.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EvictionFiler.Application.Services
{
    public class ChatGptService : IChatGptService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        public ChatGptService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            //_webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> GenerateOSC(Guid CaseId)
        {
            var apiKey = _configuration.GetSection("OpenAI:ChatGpt").Value;
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("OPENAI_API_KEY environment variable not set.");
                return false;
            }

            try
            {
                var client = new OpenAIClient(apiKey);

                // 1. Download Input File (From your API endpoint)
                var url = "/api/casefile/EF0000000002/3260a94f-4a1f-403b-a271-f62ed5aab7d4.pdf";
                var bytes = await _httpClient.GetByteArrayAsync(url);
                await using var stream = new MemoryStream(bytes);

                // 2. Upload to OpenAI (SDK DOES support this)
                var fileClient = client.GetOpenAIFileClient();
                var uploaded = await fileClient.UploadFileAsync(
                    file: stream,
                    purpose: "assistants",
                    filename: Path.GetFileName(url)
                );

                var uploadedFileId = uploaded.Value.Id;
                Console.WriteLine($"Uploaded OpenAI File ID: {uploadedFileId}");

                // NOW THE PDF GENERATION MUST USE THE RESPONSES REST API
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);
                http.DefaultRequestHeaders.Add("OpenAI-Beta", "responses=v1");
                // 3. Create OCS PDF using Responses API (REST)
                var requestBody = new
                {
                    model = "gpt-5.2",
                    input = new[]
                    {
                        new
                        {
                            role = "user",
                            content = new object[]
                            {
                                new { type = "input_text", text = "Generate an OCS to stay eviction. Dummy court and dummy case number." },
                                new { type = "input_file", file_id = uploadedFileId }
                            }
                        }
                    }
                                    
                };


                var json = JsonConvert.SerializeObject(requestBody);
                var response = await http.PostAsync(
                    "https://api.openai.com/v1/responses",
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

                var responseJson = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                var parsed = JObject.Parse(responseJson);
                var generatedPdfFileId = parsed["output"][0]["file_id"].ToString();

                // 4. Download the GENERATED PDF
                var pdfBytes = await http.GetByteArrayAsync(
                    $"https://api.openai.com/v1/files/{generatedPdfFileId}/content"
                );
                var uploadPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads");
                var outputFile = Path.Combine(
                    uploadPath,
                    $"OCS_{CaseId}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                );

                await System.IO.File.WriteAllBytesAsync(outputFile, pdfBytes);

                Console.WriteLine("Generated OCS PDF saved: " + outputFile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return false;
            }
        }

    }
}
