using Planning.Entities;

namespace Planning.Services
{
    public class FrameService
    {
        public Frame AddCardToDo(Card card, IEnumerable<Card> listToDo)
        {
            var frame = new Frame();
            var listCardsToDo = listToDo == null ? new List<Card>() : listToDo.ToList();
            listCardsToDo.Add(card);
            frame.ListToDo = listCardsToDo;
            return frame;
        }

        public Frame MoveCardInProgress(Card card, IEnumerable<Card> listToDo, IEnumerable<Card> listInProgress)
        {
            var listCardsToDo = listToDo.ToList();
            listCardsToDo.Remove(card);
            var frame = new Frame();    
            frame.ListToDo = listCardsToDo;
            var listCardsInProgress = listInProgress.ToList();
            listCardsInProgress.Add(card);
            frame.ListInProgress = listCardsInProgress;
            return frame;
        }

        public Frame MoveCardDone(Card card, IEnumerable<Card> listToDo, IEnumerable<Card> listInProgress, IEnumerable<Card> listDone)
        {
            var frame = new Frame();
            frame.ListToDo = listToDo.ToList();

            var listCardsInProgress= listInProgress.ToList();
            listCardsInProgress.Remove(card);
            frame.ListInProgress = listCardsInProgress;

            var listCardsDone = listDone == null ? new List<Card>() : listDone.ToList();
            listCardsDone.Add(card);
            frame.ListDone = listCardsDone;

            return frame;
        }
    }
}
