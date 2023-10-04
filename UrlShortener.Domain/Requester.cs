

namespace UrlShortener.Domain
{
    public class Requester
    {
        public int RequesterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Url> Urls { get; } = new();
        public List<Requests> Requests { get; } = new();

        public Requester(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
