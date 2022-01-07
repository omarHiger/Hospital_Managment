using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Bill
    {
        [Key]
        public int Bill_Id { get; set; }

        public string Bill_Examination { get; set; }
        public string Bill_Surgeries { get; set; }
        public string Bill_Rays { get; set; }
        public string Bill_Medical_Test { get; set; }
        public string Bill_Room_Service { get; set; }
        public int Patient_Id { get; set; } // Foreign Key
    }
}
