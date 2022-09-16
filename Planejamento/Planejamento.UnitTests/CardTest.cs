using Planning.Entities;
using Planning.Services;

namespace Planning.UnitTests
{
    public class CardTest
    {
        string titleOne = "title-fake";
        string descriptionOne = "description-fake";
        DateTime createdAtOne = DateTime.Now;

        string titleTwo = "title-fake";
        string descriptionTwo = "description-fake";
        DateTime createdAtTwo = DateTime.Now;

        [Fact]
        public void Deve_Criar_Um_Cartao_Na_Lista_ToDo()
        {
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne, StatusEnum.ToDo);
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            var frameFake = new Frame(listToDoFake, null, null);
            var frameService = new FrameService();
            var frame = frameService.AddCardToDo(cardFakeOne, null);
            Assert.Equal(frameFake.ListToDo.Count(), frame.ListToDo.Count());
        }

        [Fact]
        public void Deve_Criar_Dois_Cartoes_Na_Lista_ToDo()
        {
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne, StatusEnum.ToDo);
            var cardFakeTwo = new Card(titleTwo, descriptionTwo, createdAtTwo, StatusEnum.ToDo);
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            listToDoFake.Add(cardFakeTwo);
            var frameFake = new Frame(listToDoFake, null, null);
            var frameService = new FrameService();
            var frame = frameService.AddCardToDo(cardFakeOne, null);
            frame = frameService.AddCardToDo(cardFakeTwo, frame.ListToDo);
            Assert.Equal(listToDoFake.Count(), frame.ListToDo.Count());
        }

        [Fact]
        public void Deve_Mover_Cartao_Para_InProgress()
        {
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne, StatusEnum.ToDo);
            var cardFakeTwo = new Card(titleTwo, descriptionTwo, createdAtTwo, StatusEnum.ToDo);
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            listToDoFake.Add(cardFakeTwo);
            List<Card> listInProgressFake = new List<Card>();
            listInProgressFake.Add(cardFakeOne);
            var frameFake = new Frame(listToDoFake, listInProgressFake, null);
            var frameService = new FrameService();
            frameService.MoveCardInProgress(cardFakeOne, listToDoFake, listInProgressFake);
            Assert.Equal(listToDoFake.Count(), frameFake.ListToDo.Count());
            Assert.Equal(listInProgressFake.Count(), frameFake.ListInProgress.Count());
        }

        [Fact]
        public void Deve_Mover_Cartao_Para_Done()
        {
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne, StatusEnum.ToDo);
            var cardFakeTwo = new Card(titleTwo, descriptionTwo, createdAtTwo, StatusEnum.ToDo);
            
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            listToDoFake.Add(cardFakeTwo);

            List<Card> listInProgressFake = new List<Card>();
            listToDoFake.Remove(cardFakeOne);
            listInProgressFake.Add(cardFakeOne);
            
            List<Card> listDoneFake = new List<Card>();
            listInProgressFake.Remove(cardFakeOne);
            listDoneFake.Add(cardFakeOne);

            var frameFake = new Frame(listToDoFake, listInProgressFake, listDoneFake);

            var frameService = new FrameService();
            frameService.MoveCardInProgress(cardFakeOne, listToDoFake, listInProgressFake);

            frameService.MoveCardDone(cardFakeOne, listToDoFake, listInProgressFake, null);

            Assert.Equal(listToDoFake.Count(), frameFake.ListToDo.Count());
            Assert.Equal(listInProgressFake.Count(), frameFake.ListInProgress.Count());
            Assert.Equal(listDoneFake.Count(), frameFake.ListDone.Count());
        }
    }
}
