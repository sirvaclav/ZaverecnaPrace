using SIR_Zaverecna_Prace.Data;
using SIR_Zaverecna_Prace.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIR_Zaverecna_Prace.Models
{
    public class DeveloperEditorViewModel : IValidatableObject
    {
        public DeveloperEditorViewModel()
        { }

        public DeveloperEditorViewModel(Developer developer)
        {
            this.Id = developer.Id;
            this.Name = developer.Name;
            this.FoundedAt = developer.FoundedAt;
            this.Residence = developer.Residence;
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Název")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Založeno")]
        public DateTime FoundedAt { get; set; }

        [DisplayName("Sídlo")]
        public string Residence { get; set; }

        public void UpdateEntity(Developer developer)
        {

            developer.Name = this.Name;
            developer.FoundedAt = this.FoundedAt;
            developer.Residence = this.Residence;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var developer = context.Publishers.FirstOrDefault(b => b.Id == this.Id);

            if (developer == null)
                yield return new ValidationResult("Nehraj si se stránkou", new string[] { nameof(Id) });

            if (developer != null && developer.Games.Any(c => c.PublishedAt < this.FoundedAt))
                yield return new ValidationResult("Vývojář nemůže dokončit vývoj před založením", new string[] { nameof(FoundedAt) });
        }
    }
}
