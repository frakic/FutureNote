using FutureNote.BusinessLogic.Interfaces;
using FutureNote.Entities.Entities;
using System;
using System.Threading.Tasks;
using FutureNote.DataAccess.Interfaces;

namespace FutureNote.BusinessLogic.Workflows
{
    public class NoteWorkflow : INoteWorkflow
    {
        private readonly INoteRepository noteRepository;

        public NoteWorkflow(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<Note> CreateNote(Note note)
        {
            await noteRepository.SaveNoteToDb(note);
            return note;
        }

        public async Task<Note> FindNoteByGuid(string guid)
        {
            if (guid.Length == 10)
            {
                Note note = await noteRepository.FindNoteByGuid(guid);
                return note;
            }
            else
            {
                throw new ArgumentException("GUID must be exactly 10 characters long.");
            }
        }

        public async Task<Note> FindNoteById(int id)
        {
            Note note = await noteRepository.FindNoteById(id);
            return note;
        }

        public async Task<Note> OpenNote(Note note)
        {
            //Status -> Open; FirstRead -> Today
            UpdateNoteStatusAndDate(note);
            await noteRepository.UpdateNoteInDb(note);
            return note;
        }

        private Note UpdateNoteStatusAndDate(Note note)
        {
            note.Status = NoteStatus.Open;
            note.FirstRead = DateTime.Today;

            return note;
        }
    }
}
