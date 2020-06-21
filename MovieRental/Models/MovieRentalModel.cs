namespace MovieRental.Models
{
    public class MovieRentalModel
    {
        public int Id { get; set; }

        public string DateEnd { get; set; }

        public MovieModel Movie { get; set; }

        public decimal Price { get; set; }
    }
}
