namespace ContactBook.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;   

    public ICollection<ContactNote> ContactNote { get; set; } = new List<ContactNote>();
        public ICollection<ContactTag> ContactTag { get; set; } = new List<ContactTag>();
    }
}
