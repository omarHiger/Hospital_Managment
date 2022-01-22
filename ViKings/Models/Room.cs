using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViKings.Models
{
    public class Room
    {
        [Key]
        public int Room_Id { get; set; }
        [Required]
        [Display(Name ="Available")]
        public bool Room_Empty { get; set; } = true; // Empty == true ,,, not empty == false ;
        [Display(Name = "Type")]
        public string Room_Type { get; set; }
        public int Serial_Number { get; set; } // ForeignKey
        
        [ForeignKey("Room_Id")]
        public virtual ICollection<Reservation> Room_Reservations { get; set; }
    }
}
