using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BreakTables
{
    public class Caring
    {
        [Key] [Column(Order =1)]
        public int Doctor_Id { get; set; }
        [Key] [Column(Order = 2)]
        public int Patient_Id { get; set; }
    }
}
