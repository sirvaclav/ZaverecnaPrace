using SIR_Zaverecna_Prace.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIR_Zaverecna_Prace.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime PublishedAt { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int DeveloperId { get; set; }

        [ForeignKey(nameof(PublisherId))]
        public virtual Publisher Publisher
        {
            get;
            set;
        }

        [ForeignKey(nameof(DeveloperId))]
        public virtual Developer Developer
        {
            get;
            set;
        }

        public static Game Create(string name, DateTime publishedAt, GameGenre genre, int publisher, int developer)
        {
            var model = new Game()
            {
                Name = name,
                PublishedAt = publishedAt,
                Genre = genre,
                PublisherId = publisher,
                DeveloperId = developer
            };

            return model;
        }
    }
}
