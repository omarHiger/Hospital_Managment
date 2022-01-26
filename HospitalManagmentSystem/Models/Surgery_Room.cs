using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.Models
{
    public class Surgery_Room
    {
        [Key]
        public int Surgery_Room_Id { get; set; }
        [Display(Name = "Available")]
        public bool Surgery_Room_Ready { get; set; } = true;  // ready == true  ,,, not ready == false
        [Required]
        public int Ho_Id { get; set; } // Foreign Key

        [ForeignKey("Surgery_Room_Id")]
        public virtual List<Surgery> Surgery_Room_Surgeries { get; set; } = new List<Surgery>();
    }
}
