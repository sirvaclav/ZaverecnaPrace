using SIR_Zaverecna_Prace.Code;
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
    public class GameEditorViewModel : IValidatableObject
    {
        public GameEditorViewModel()
        { }

        public GameEditorViewModel(Game game)
        {
            this.Name = game.Name;
            this.Genre = game.Genre;
            this.PublishedAt = game.PublishedAt;
            this.PublisherId = game.PublisherId;
            this.DeveloperId = game.DeveloperId;
        }

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

        public void UpdateEntity(Game game)
        {
            game.Name = this.Name;
            game.Genre = this.Genre;
            game.PublishedAt = this.PublishedAt;
            game.PublisherId = this.PublisherId;
            game.DeveloperId = this.DeveloperId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

            var game = context.Games.FirstOrDefault(c => c.Id == this.Id);

            if (game == null)
                yield return new ValidationResult("Nehraj si se stránkou", new string[] { nameof(this.Id) });

            if (game != null && game.Publisher.FoundedAt > this.PublishedAt)
                yield return new ValidationResult("Hra nemůže vzniknout před vydavatelem", new string[] { nameof(this.PublishedAt) });

            if (game != null && game.Developer.FoundedAt > this.PublishedAt)
                yield return new ValidationResult("Hra nemůže vzniknout před vývojářem", new string[] { nameof(this.PublishedAt) });
        }
    }
}
