using UrlShortener.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Domain
{
    public  class Requests : AuditModel
    {
        public int UrlId { get; set; }
        public int RequesterId { get; set; }
        public Guid RequestGuid { get; private set; } = Guid.Empty;

        [ForeignKey("UrlId")]
        public virtual Url Url { get; set; }
        [ForeignKey("RequesterId")]
        public virtual Requester Requester { get; set; }
        public Requests() { }

        private void SetGuid(Guid guid)
        {
            RequestGuid = guid;

        }

        public void SetGuid()
        {
            RequestGuid = Guid.NewGuid();

        }

        public static Requests Create(Url targetUrl, Requester requester)
        {
            var newRequest = new Requests
            {
                Url = targetUrl,
                Requester = requester
            };

            return newRequest;

        }
    }
}
