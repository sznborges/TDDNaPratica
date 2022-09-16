namespace Planning.Entities
{
    public class Card
    {
        public Card(string title, string description, DateTime createdAt)
        {
            Title = title;
            Description = description;
            CreatedAt = createdAt;

        }
        public Card(string title, string description)
        {
            Title =title;
            Description = description;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
