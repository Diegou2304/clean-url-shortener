namespace UrlShortener.Domain.Common
{
    public  abstract class AuditModel
    {
        public DateTime? CreationDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
