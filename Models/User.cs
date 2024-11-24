namespace BookingService.Models
{
    public class User
    {
        public User(long id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
