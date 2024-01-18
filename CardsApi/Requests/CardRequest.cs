using CardsApi.Enums;

namespace CardsApi.Requests
{
    public class CardRequest : CreateCardRequest
    {
        public Guid Id {  get; set; }
        public Status? Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
