using Microsoft.Build.Framework;

namespace objStorageServer.Models
{
    public class Attributes_TableAttribute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableAttributeId { get; set; }
        [Required]
        public int AttributeId { get; set; }
    }
}
