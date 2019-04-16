using SIR_Zaverecna_Prace.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIR_Zaverecna_Prace.Models
{
    public class DeveloperCreatorViewModel
    {
        public DeveloperCreatorViewModel()
        { }

        public int Id { get; set; }

        [Required]
        [DisplayName("Název")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Založeno")]
        public DateTime FoundedAt { get; set; }

        [DisplayName("Sídlo")]
        public string Residence { get; set; }

        public Developer CreateEntity()
        {
            var developer = Developer.Create(Name, FoundedAt, Residence);

            return developer;
        }
    }
}
