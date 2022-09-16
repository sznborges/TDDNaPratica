namespace Planning.Entities
{
    public class Frame
    {
        public IEnumerable<Card> ListToDo { get; set; }
        public IEnumerable<Card> ListInProgress { get; set; }
        public IEnumerable<Card> ListDone { get; set; }

        public Frame()
        {

        }

        public Frame(IEnumerable<Card> listToDo, IEnumerable<Card> listInProgress, IEnumerable<Card> listDone)
        {
            ListToDo = listToDo;
            ListInProgress = listInProgress;
            ListDone = listDone;
        }
    }
}
