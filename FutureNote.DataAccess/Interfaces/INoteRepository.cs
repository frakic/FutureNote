using FutureNote.Entities.Entities;
using System.Threading.Tasks;

namespace FutureNote.DataAccess.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> FindNoteByGuid(string guid);
        Task<Note> FindNoteById(int id);
        Task<Note> SaveNoteToDb(Note note);
        Task<Note> UpdateNoteInDb(Note note);
    }
}