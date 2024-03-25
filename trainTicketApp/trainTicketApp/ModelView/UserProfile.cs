namespace trainTicketApp.ModelView
{
    public class UserProfile
    {
        public string? FirstName { get; set; } = default!;

        public string? LastName { get; set; } = default!;
        public string? Role { get; set; } = default!;

        public string? NickName { get; set; } = default!;

        public string EmailAddress { get; set; } = default!;

        public bool IsAdmin { get; set; } 
    }
}
