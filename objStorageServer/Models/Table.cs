using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace objStorageServer.Models
{
    public class Table
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
