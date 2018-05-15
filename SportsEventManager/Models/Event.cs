using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportsEventManager.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }
       
        public DateTime? Started { get; set; }

        public DateTime? Ended { get; set; }

        public string TournamentName { get; set; }

        [Required]
        public string HostName { get; set; }
        [Required]
        public string GuestName { get; set; }

    }
}
