using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIR_Zaverecna_Prace.Entities
{
    public class Publisher
    {
        public Publisher()
        {
            this.Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime FoundedAt { get; set; }
        public string Residence { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public static Publisher Create(string name, DateTime foundedAt, string residence)
        {
            var model = new Publisher()
            {
                Name = name,
                FoundedAt = foundedAt,
                Residence = residence
            };

            return model;
        }
    }
}
