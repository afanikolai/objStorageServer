using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace objStorageServer.Models
{
    public class Document
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DocumentFileId { get; set; }
        [Required]
        public int DocumentSettingsId { get; set; }
    }
}
