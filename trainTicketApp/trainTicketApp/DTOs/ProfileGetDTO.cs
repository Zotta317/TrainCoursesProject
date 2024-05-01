namespace trainTicketApp.DTOs
{
    public class ProfileGetDTO
    {
        public string? Name { get; set; } = default!;
        public string? Role { get; set; } = default!;

        public string? NickName { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;

        public bool IsAdmin { get; set; }
    }
}
