using EnglishTutorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnglishTutorAPI.Controllers
{
    [ApiController]
    [Route("api/english-tutor")]
    public class EnglishTutorController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public EnglishTutorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [HttpGet]
        public async Task<IActionResult> Get(string text, [FromServices] IConfiguration configuration)
        {
            var token = "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";

            _httpClient.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", token);

            //MONTANDO RQUISIÇÃO
            var model = new ChatGptInputModel(text);
            var requestBody = JsonSerializer.Serialize(model);
            var context = new StringContent(requestBody, Encoding.UTF8, "application/json");

            //ENVIANDO REQUISIÇÃO
            var response =
                await _httpClient.PostAsync("https://api.openai.com/v1/completions", context);

            //RECEBENDO RESPOSTA DA REQUISIÇÃO
            var result = await response.Content.ReadFromJsonAsync<ChatGptViewModel>();
            var promptResponse = result.choices.First();

            return Ok(promptResponse);
        }
    }
}
