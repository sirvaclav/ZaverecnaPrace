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
    public class PublisherEditorViewModel : IValidatableObject
    {
        public PublisherEditorViewModel()
        { }

        public PublisherEditorViewModel(Publisher publisher)
        {
            this.Id = publisher.Id;
            this.Name = publisher.Name;
            this.FoundedAt = publisher.FoundedAt;
            this.Residence = publisher.Residence;
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

        public void UpdateEntity(Publisher publisher)
        {

            publisher.Name = this.Name;
            publisher.FoundedAt = this.FoundedAt;
            publisher.Residence = this.Residence;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var publisher = context.Publishers.FirstOrDefault(b => b.Id == this.Id);

            if (publisher == null)
                yield return new ValidationResult("Nehraj si se stránkou", new string[] { nameof(Id) });

            if (publisher != null && publisher.Games.Any(c => c.PublishedAt < this.FoundedAt))
                yield return new ValidationResult("Vydavatel nemůže vydat hru před založením", new string[] { nameof(FoundedAt) });
        }
    }
}
