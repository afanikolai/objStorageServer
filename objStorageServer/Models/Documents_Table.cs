using Microsoft.Build.Framework;

namespace objStorageServer.Models
{
    public class Documents_Table
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DocId { get; set; }
        [Required]
        public int TableId { get; set; }
    }
}
