namespace AngDotNet.Models.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public required string PhoneNumber { get; set; }
        public bool Favourite { get; set; }

    }
}
