
using EvictionFiler.Application.Constants;
using EvictionFiler.Application.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAI;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EvictionFiler.Application.Services
{
    public class ChatGptService : IChatGptService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ICaseFormService _CaseFormService;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        public ChatGptService(IConfiguration configuration, HttpClient httpClient, ICaseFormService CaseFormService)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _CaseFormService = CaseFormService;
            //_webHostEnvironment = webHostEnvironment;
        }

        public async Task<string?> GenerateOSC(Guid CaseId)
        {
            var apiKey = _configuration.GetSection("OpenAI:ApiKey").Value;
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("OPENAI_API_KEY environment variable not set.");
                return null;
            }

            try
            {
                var client = new OpenAIClient(apiKey);

                List<string> uploadedFileIds = new List<string>();
                var caseFormDto = await _CaseFormService.GetCaseFormsPathByCaseId(CaseId);
                // 1. Download Input File (From your API endpoint)
                foreach (var form in caseFormDto)
                {
                    string? url = form.File.Replace("/CaseForms/","");
                    var bytes = await _httpClient.GetByteArrayAsync($"/api/casefile/{url}");
                    await using var stream = new MemoryStream(bytes);

                    // 2. Upload to OpenAI (SDK DOES support this)
                    var fileClient = client.GetOpenAIFileClient();
                    var uploaded = await fileClient.UploadFileAsync(
                        file: stream,
                        purpose: "assistants",
                        filename: Path.GetFileName(url)
                    );

                    var uploadedFileId = uploaded.Value.Id;
                    uploadedFileIds.Add(uploadedFileId);
                    Console.WriteLine($"Uploaded OpenAI File ID: {uploadedFileId}");
                }


                // NOW THE PDF GENERATION MUST USE THE RESPONSES REST API
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);
                http.DefaultRequestHeaders.Add("OpenAI-Beta", "responses=v1");

                var contentItems = new List<object>
                {
                    new { type = "input_text", text = OpenAIPrompts.OSCPrompt }
                };

                foreach (var fid in uploadedFileIds)
                {
                    contentItems.Add(new { type = "input_file", file_id = fid });
                }

                var requestBody = new
                {
                    model = "gpt-5-nano",
                    input = new[]
                    {
                        new
                        {
                            role = "user",
                            content = contentItems.ToArray()
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

                var result = ExtractTextFromResponse(responseJson);
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return null;
            }
        }
        public async Task<string?> GenerateMotion(Guid CaseId)
        {
            var apiKey = _configuration.GetSection("OpenAI:ApiKey").Value;
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("OPENAI_API_KEY environment variable not set.");
                return null;
            }

            try
            {
                var client = new OpenAIClient(apiKey);

                List<string> uploadedFileIds = new List<string>();
                var caseFormDto = await _CaseFormService.GetCaseFormsPathByCaseId(CaseId);
                // 1. Download Input File (From your API endpoint)
                foreach (var form in caseFormDto)
                {
                    string? url = form.File.Replace("/CaseForms/","");
                    var bytes = await _httpClient.GetByteArrayAsync($"/api/casefile/{url}");
                    await using var stream = new MemoryStream(bytes);

                    // 2. Upload to OpenAI (SDK DOES support this)
                    var fileClient = client.GetOpenAIFileClient();
                    var uploaded = await fileClient.UploadFileAsync(
                        file: stream,
                        purpose: "assistants",
                        filename: Path.GetFileName(url)
                    );

                    var uploadedFileId = uploaded.Value.Id;
                    uploadedFileIds.Add(uploadedFileId);
                    Console.WriteLine($"Uploaded OpenAI File ID: {uploadedFileId}");
                }


                // NOW THE PDF GENERATION MUST USE THE RESPONSES REST API
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);
                http.DefaultRequestHeaders.Add("OpenAI-Beta", "responses=v1");

                var contentItems = new List<object>
                {
                    new { type = "input_text", text = OpenAIPrompts.MotionPrompt }
                };

                foreach (var fid in uploadedFileIds)
                {
                    contentItems.Add(new { type = "input_file", file_id = fid });
                }

                var requestBody = new
                {
                    model = "gpt-5-nano",
                    input = new[]
                    {
                        new
                        {
                            role = "user",
                            content = contentItems.ToArray()
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

                var result = ExtractTextFromResponse(responseJson);
                //var parsed = JObject.Parse(responseJson);
                //var generatedPdfFileId = parsed["output"][0]["file_id"].ToString();

                //// 4. Download the GENERATED PDF
                //var pdfBytes = await http.GetByteArrayAsync(
                //    $"https://api.openai.com/v1/files/{generatedPdfFileId}/content"
                //);
                //var uploadPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads");
                //var outputFile = Path.Combine(
                //    uploadPath,
                //    $"OCS_{CaseId}_{DateTime.Now:yyyyMMddHHmmss}.pdf"
                //);

                //await System.IO.File.WriteAllBytesAsync(outputFile, pdfBytes);

                //Console.WriteLine("Generated OCS PDF saved: " + outputFile);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return null;
            }
        }
        private string ExtractTextFromResponse(string json)
        {
            var doc = JsonDocument.Parse(json);

            var outputArray = doc.RootElement.GetProperty("output");

            foreach (var item in outputArray.EnumerateArray())
            {
                // We want the message block
                if (item.GetProperty("type").GetString() == "message")
                {
                    var contentArray = item.GetProperty("content");

                    foreach (var content in contentArray.EnumerateArray())
                    {
                        if (content.GetProperty("type").GetString() == "output_text")
                        {
                            return content.GetProperty("text").GetString();
                        }
                    }
                }
            }

            return null; // nothing found
        }
    }
}
