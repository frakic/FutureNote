using FutureNote.Entities.Entities;
using System.Threading.Tasks;

namespace FutureNote.BusinessLogic.Interfaces
{
    public interface INoteWorkflow
    {
        Task<Note> OpenNote(Note note);
        Task<Note> FindNoteByGuid(string guid);
        Task<Note> FindNoteById(int id);
        Task<Note> CreateNote(Note note);
    }
}