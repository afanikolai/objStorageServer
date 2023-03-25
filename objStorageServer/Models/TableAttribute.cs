using Newtonsoft.Json;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objStorageServer.Models
{
    public class TableAttribute
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string Type { get; set; }

    }
}
