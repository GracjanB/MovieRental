namespace MovieRental.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public int ProductionYear { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }

        public string Scenario { get; set; }

        public decimal PricePerDay { get; set; }

        public int Rating { get; set; }
    }
}
