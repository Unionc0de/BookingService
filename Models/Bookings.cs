namespace BookingService.Models
{
    public class Bookings
    {
        public Bookings(string name, DateTime bookingDate,string details)
        {
            Id = Guid.NewGuid();
            Name = name;
            Details = details;
            BookingDate = bookingDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
