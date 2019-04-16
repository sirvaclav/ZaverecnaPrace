using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIR_Zaverecna_Prace.Entities;
using SIR_Zaverecna_Prace.Models;

namespace SIR_Zaverecna_Prace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<SIR_Zaverecna_Prace.Models.GameEditorViewModel> GameEditorViewModel { get; set; }

        public DbSet<SIR_Zaverecna_Prace.Models.GameCreatorViewModel> GameCreatorViewModel { get; set; }

        public DbSet<SIR_Zaverecna_Prace.Models.DeveloperCreatorViewModel> DeveloperCreatorViewModel { get; set; }

        public DbSet<SIR_Zaverecna_Prace.Models.DeveloperEditorViewModel> DeveloperEditorViewModel { get; set; }

        public DbSet<SIR_Zaverecna_Prace.Models.PublisherCreatorViewModel> PublisherCreatorViewModel { get; set; }

        public DbSet<SIR_Zaverecna_Prace.Models.PublisherEditorViewModel> PublisherEditorViewModel { get; set; }
    }
}
