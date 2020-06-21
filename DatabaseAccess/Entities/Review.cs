namespace DatabaseAccess.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
