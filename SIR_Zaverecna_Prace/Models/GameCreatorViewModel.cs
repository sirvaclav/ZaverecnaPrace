using SIR_Zaverecna_Prace.Code;
using SIR_Zaverecna_Prace.Data;
using SIR_Zaverecna_Prace.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIR_Zaverecna_Prace.Models
{
    public class GameCreatorViewModel : IValidatableObject
    {
        public GameCreatorViewModel()
        { }

        public int Id { get; set; }

        [Required]
        [DisplayName("Název")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Založeno")]
        public DateTime PublishedAt { get; set; }

        [Required]
        [DisplayName("Žánr")]
        public GameGenre Genre { get; set; }

        [Required]
        [DisplayName("Vydavatel")]
        public int PublisherId { get; set; }

        [Required]
        [DisplayName("Vývojář")]
        public int DeveloperId { get; set; }

        [NotMapped]
        public Dictionary<int, string> Publishers { get; set; }

        [NotMapped]
        public Dictionary<int, string> Developers { get; set; }

        public Game CreateEntity()
        {
            var game = Game.Create(Name, PublishedAt, Genre, PublisherId, DeveloperId);

            return game;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var publisher = context.Publishers.FirstOrDefault(p => p.Id == this.PublisherId);
            var developer = context.Developers.FirstOrDefault(d => d.Id == DeveloperId);

            if (publisher == null)
                yield return new ValidationResult("Nehraj si se stránkou", new string[] { nameof(this.PublisherId) });
            if (developer == null)
                yield return new ValidationResult("Nehraj si se stránkou", new string[] { nameof(this.DeveloperId) });

            if (publisher != null && publisher.FoundedAt > this.PublishedAt)
                yield return new ValidationResult("Hra nemůže vzniknout před vydavatelem", new string[] { nameof(this.PublishedAt) });
            if (developer != null && developer.FoundedAt > this.PublishedAt)
                yield return new ValidationResult("Auto nemůže vzniknout před vývojářem", new string[] { nameof(this.PublishedAt) });
        }
    }
}
