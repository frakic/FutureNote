using FutureNote.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace FutureNote.DataAccess
{
    public class FutureNoteContext : DbContext
    {
        public FutureNoteContext(DbContextOptions<FutureNoteContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Note> Notes { get; set; }
    }
}