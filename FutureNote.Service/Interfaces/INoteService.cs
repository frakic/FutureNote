using FutureNote.Service.DTOs;
using System.Threading.Tasks;

namespace FutureNote.Service.Interfaces
{
    public interface INoteService
    {
        Task<NoteDto> FindNoteByGuid(string guid);
        Task<NoteDto> FindNoteById(int id);
        Task<NoteDto> OpenNote(int id);
        Task<NoteDto> CreateNote(NoteDto noteDto);
        string GenerateGuid();
    }
}
