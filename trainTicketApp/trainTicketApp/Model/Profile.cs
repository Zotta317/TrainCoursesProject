namespace trainTicketApp.Model
{
    public class Profile
    {
        public Guid ID { get; set; }

        public string? FirstName { get; set; } = default!;

        public string? LastName { get; set; } = default!;

        public string? Role { get; set; } = default!;

        public string? NickName { get; set; } = default!;

        public string? EmailAddress { get; set; } = default!;

        public List<Ticket> Tickets { get; set; } 

        public bool IsAdmin { get; set; }
    }
}
