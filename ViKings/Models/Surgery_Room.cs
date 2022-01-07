using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Surgery_Room
    {
        [Key]
        public int Surgery_Room_Id { get; set; }
        [Required]
        [Display(Name = "Available")]
        public bool Surgery_Room_Ready { get; set; } = true;  // ready == true  ,,, not ready == false
        public int Serial_Number { get; set; } // Foreign Key

        [ForeignKey("Surgery_Room_Id")]
        public virtual ICollection<Surgery> Surgery_Room_Surgeries { get; set; }
    }
}
