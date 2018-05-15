using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Models
{
    public class Volleyball
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }

        [Required]
        public int HostScore { get; set; }
        [Required]
        public int GuestScore { get; set; }

        [Required]
        public int HostSetScore { get; set; }
        [Required]
        public int GuestSetScore { get; set; }

    }
}
