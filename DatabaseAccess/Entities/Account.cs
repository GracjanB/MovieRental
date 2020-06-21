using System.Collections.Generic;

namespace DatabaseAccess.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public decimal Balance { get; set; }

        public Role Role { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<VideoRental> VideoRentals { get; set; }
    }

    public enum Role
    {
        USER,
        ADMINISTRATOR
    }
}
