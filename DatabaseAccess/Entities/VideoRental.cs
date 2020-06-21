using System;

namespace DatabaseAccess.Entities
{
    public class VideoRental
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public Status Status { get; set; }

        public decimal Price { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }

    public enum Status
    {
        CREATED,
        AVAILABLE,
        ENDED
    }
}
