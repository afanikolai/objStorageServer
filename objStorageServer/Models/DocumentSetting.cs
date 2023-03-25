using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace objStorageServer.Models
{
    public class DocumentSetting
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AssigneeId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public string? Comment { get; set; }


    }
}
