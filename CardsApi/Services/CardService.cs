using CardsApi.Abstractions.Mappers;
using CardsApi.Abstractions.Repositories;
using CardsApi.Abstractions.Services;
using CardsApi.Dtos;
using CardsApi.Models;
using CardsApi.Requests;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace CardsApi.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper<Card, CardDto> _cardDtoMapper;
        private readonly IMapper<CardRequest, Card> _cardMapper;
        private readonly IMapper<CreateCardRequest, Card> _createRequestToCardMapper;
        private readonly IMapper<Card, CardRequest> _cardRequestMapper;
        private readonly IValidator<Card> _cardValidator;
        private readonly IUnitOfWork _unitOfWork;

        public CardService(
            ICardRepository cardRepository,
            IMapper<Card, CardDto> cardDtoMapper,
            IMapper<Card, CardRequest> cardRequestMapper,
            IMapper<CardRequest, Card> cardMapper,
            IMapper<CreateCardRequest, Card> createRequestToCardMapper,
            IValidator<Card> cardValidator,
            IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository ?? throw new ArgumentException(nameof(cardRepository));
            _cardDtoMapper = cardDtoMapper ?? throw new ArgumentException(nameof(cardDtoMapper));
            _cardRequestMapper = cardRequestMapper ?? throw new ArgumentException(nameof(cardRequestMapper));
            _cardMapper = cardMapper ?? throw new ArgumentException(nameof(cardMapper));
            _createRequestToCardMapper = createRequestToCardMapper ?? throw new ArgumentException(nameof(createRequestToCardMapper));
            _cardValidator = cardValidator ?? throw new ArgumentException(nameof(cardValidator));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CardDto> GetByIdAsync(
            Guid id,
            CancellationToken token = default)
        {
            var card = await _cardRepository.GetByIdAsync(id, token);
            return _cardDtoMapper.Map(card);
        }

        public async Task<IEnumerable<CardDto>> GetAsync(
            CardRequest request,
            CancellationToken token = default)
        {
            var cards = await _cardRepository.GetAsync(request, token);
            return _cardDtoMapper.Map(cards);
        }

        public async Task<CardDto> CreateAsync(
            CardRequest request,
            CancellationToken token = default)
        {
            var addedCard = _createRequestToCardMapper.Map(request);

            await _cardValidator.ValidateAndThrowAsync(addedCard);
            var result = await _cardRepository.CreateAsync(addedCard, token);

            await _unitOfWork.SaveAsync(token);

            return _cardDtoMapper.Map(result);
        }

        public async Task<CardDto> UpdateAsync(
            Guid id,
            JsonPatchDocument<CardRequest> patchDocument,
            CancellationToken token = default)
        {
            var card = await _cardRepository.GetByIdAsync(id, token);

            var updateRequest = _cardRequestMapper.Map(card);
            patchDocument.ApplyTo(updateRequest);
            var updatedCard = _cardMapper.Map(updateRequest);

            await _cardValidator.ValidateAndThrowAsync(updatedCard);

            var result = _cardRepository.Update(card, updatedCard);

            await _unitOfWork.SaveAsync(token);

            return _cardDtoMapper.Map(result);
        }

        public async Task<CardDto> DeleteAsync(
            Guid id,
            CancellationToken token = default)
        {
            var result = await _cardRepository.DeleteAsync(id, token);
            await _unitOfWork.SaveAsync(token);

            return _cardDtoMapper.Map(result);
        }
    }
}
