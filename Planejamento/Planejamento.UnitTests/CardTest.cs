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
            //Expected
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne);
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            var frameFake = new Frame(listToDoFake, null, null);
            //Actual
            var frameService = new FrameService();
            var frame = frameService.AddCardToDo(cardFakeOne, null);
            //Assert
            Assert.Equal(frameFake.ListToDo.Count(), frame.ListToDo.Count());
        }

        [Fact]
        public void Deve_Criar_Dois_Cartoes_Na_Lista_ToDo()
        {
            //Expected
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne);
            var cardFakeTwo = new Card(titleTwo, descriptionTwo, createdAtTwo);
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            listToDoFake.Add(cardFakeTwo);
            var frameFake = new Frame(listToDoFake, null, null);
            //Actual
            var frameService = new FrameService();
            var frame = frameService.AddCardToDo(cardFakeOne, null);
            frame = frameService.AddCardToDo(cardFakeTwo, frame.ListToDo);
            //Assert
            Assert.Equal(listToDoFake.Count(), frame.ListToDo.Count());
        }

        [Fact]
        public void Deve_Mover_Cartao_Para_InProgress()
        {
            //Expected
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne);
            var cardFakeTwo = new Card(titleTwo, descriptionTwo, createdAtTwo);
            List<Card> listToDoFake = new List<Card>();
            listToDoFake.Add(cardFakeOne);
            listToDoFake.Add(cardFakeTwo);
            List<Card> listInProgressFake = new List<Card>();
            listToDoFake.Remove(cardFakeOne);
            listInProgressFake.Add(cardFakeOne);
            var frameFake = new Frame(listToDoFake, listInProgressFake, null);
            //Actual
            var frameService = new FrameService();
            var frame = frameService.AddCardToDo(cardFakeOne, null);
            frame = frameService.AddCardToDo(cardFakeTwo, frame.ListToDo);
            frame = frameService.MoveCardInProgress(cardFakeOne, frame.ListToDo, frame.ListInProgress);
            //Assert
            Assert.Equal(listToDoFake.Count(), frame.ListToDo.Count());
            Assert.Equal(listInProgressFake.Count(), frame.ListInProgress.Count());
        }

        [Fact]
        public void Deve_Mover_Cartao_Para_Done()
        {
            //Expected
            var cardFakeOne = new Card(titleOne, descriptionOne, createdAtOne);
            var cardFakeTwo = new Card(titleTwo, descriptionTwo, createdAtTwo);
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
            //Actual
            var frameService = new FrameService();
            var frame = frameService.AddCardToDo(cardFakeOne, null);
            frame = frameService.AddCardToDo(cardFakeTwo, frame.ListToDo);
            frame = frameService.MoveCardInProgress(cardFakeOne, frame.ListToDo, null);
            frame = frameService.MoveCardDone(cardFakeOne, frame.ListToDo, frame.ListInProgress, null);
            //Assert
            Assert.Equal(listToDoFake.Count(), frame.ListToDo.Count());
            Assert.Equal(listInProgressFake.Count(), frame.ListInProgress.Count());
            Assert.Equal(listDoneFake.Count(), frame.ListDone.Count());
        }
    }
}
