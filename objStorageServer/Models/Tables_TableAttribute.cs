using Microsoft.Build.Framework;

namespace objStorageServer.Models
{
    public class Tables_TableAttribute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        [Required]
        public int TableAttributeId { get; set; }
    }
}
