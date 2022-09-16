namespace Planning.Entities
{
    public class Card
    {
        public Card(string title, string description, DateTime createdAt, StatusEnum status)
        {
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            Status = status;

        }
        public Card(string title, string description, StatusEnum status)
        {
            Title =title;
            Description = description;
            Status = status;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public StatusEnum Status { get; private set; }
    }
}
