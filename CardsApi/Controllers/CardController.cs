using CardsApi.Abstractions.Services;
using CardsApi.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CardsApi.Controllers
{
    [ApiController]
    [Route("api/card")]
    [Authorize]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService ?? throw new ArgumentNullException(nameof(cardService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] Guid id,
            CancellationToken token = default)
        {
            var result = await _cardService.GetByIdAsync(id, token);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] CardRequest request,
            CancellationToken token = default)
        {
            var result = await _cardService.GetAsync(request, token);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CardRequest request,
            CancellationToken token = default)
        {
            var result = await _cardService.CreateAsync(request, token);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] Guid id,
            [FromBody] JsonPatchDocument<CardRequest> request,
            CancellationToken token = default)
        {
            var result = await _cardService.UpdateAsync(id, request, token);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] Guid id,
            CancellationToken token = default)
        {
            var result = await _cardService.DeleteAsync(id, token);
            return Ok(result);
        }
    }
}
