using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Category Category { get; set; }

        public int ProductionYear { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string Director { get; set; }

        public string Scenario { get; set; }

        public decimal PricePerDay { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<VideoRental> VideoRentals { get; set; }
    }

    public enum Category
    {
        Action,
        Animated,
        Adventure,
        Biographical,
        Comedy,
        Criminal,
        Documentary,
        Drama,
        Fantasy,
        Historical,
        Horror,
        Nature,
        Parody,
        Political,
        SciFi,
        Science,
        Thriller,
        Western,
        War
    }
}
