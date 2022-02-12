using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LastHMS1.BreakTables
{
    public class Caring
    {
        [Key] [Column(Order =1)]
        public int Doctor_Id { get; set; } // foreign key // cascade
        [Key] [Column(Order = 2)]
        public int Patient_Id { get; set; } // foreign key // cascade
    }
}
