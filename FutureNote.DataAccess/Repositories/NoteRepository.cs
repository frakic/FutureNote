using FutureNote.DataAccess.Interfaces;
using FutureNote.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FutureNote.DataAccess.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly FutureNoteContext context;

        public NoteRepository(FutureNoteContext context)
        {
            this.context = context;
        }

        public async Task<Note> FindNoteByGuid(string guid)
        {
            Note note = await context.Notes.FirstOrDefaultAsync(n => n.Guid == guid);
            return note;
        }

        public async Task<Note> FindNoteById(int id)
        {
            Note note = await context.Notes.FindAsync(id);
            return note;
        }

        public async Task<Note> SaveNoteToDb(Note note)
        {
            try
            {
                context.Add(note);
                await context.SaveChangesAsync();
                return note;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(note.Id))
                {
                    throw new Exception("Concurrency violation encountered while saving note to database. Note was not saved.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Note> UpdateNoteInDb(Note note)
        {
            context.Update(note);
            await context.SaveChangesAsync();
            return note;
        }

        private bool NoteExists(int id)
        {
            return context.Notes.Any(e => e.Id == id);
        }
    }
}