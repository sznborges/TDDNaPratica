using Planning.Entities;

namespace Planning.Services
{
    public class CardService
    {
        public IEnumerable<Card> InsertCardToDo(Card card)
        {
            List<Card> cards = new List<Card>();
            cards.Add(card);
            return cards.ToArray();
        }
    }
}
