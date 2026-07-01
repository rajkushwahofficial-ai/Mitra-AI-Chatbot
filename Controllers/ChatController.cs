using Microsoft.AspNetCore.Mvc;
using ChatBotProject.Models;
using ChatBotProject.Services;

namespace ChatBotProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly OllamaService _ollama;

        public ChatController(OllamaService ollama)
        {
            _ollama = ollama;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var reply = await _ollama.Ask(request.Message);

            return Ok(new ChatResponse
            {
                Reply = reply
            });
        }
    }
}