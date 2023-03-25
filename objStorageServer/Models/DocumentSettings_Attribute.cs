using Microsoft.Build.Framework;

namespace objStorageServer.Models
{
    public class DocumentSettings_Attribute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AttributeId { get; set; }
        [Required]
        public int DocumentSettingsId { get; set; }
    }
}
