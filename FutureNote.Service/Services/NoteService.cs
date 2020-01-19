using AutoMapper;
using FutureNote.BusinessLogic.Interfaces;
using FutureNote.Entities.Entities;
using FutureNote.Service.DTOs;
using FutureNote.Service.Interfaces;
using shortid;
using System;
using System.Threading.Tasks;

namespace FutureNote.Service.Services
{
    public class NoteService : INoteService
    {
        private readonly IMapper mapper;
        private readonly INoteWorkflow noteWorkflow;

        public NoteService(IMapper mapper, INoteWorkflow noteWorkflow)
        {
            this.mapper = mapper;
            this.noteWorkflow = noteWorkflow;
        }

        public async Task<NoteDto> FindNoteByGuid(string guid)
        {
            try
            {
                Note note = await noteWorkflow.FindNoteByGuid(guid);
                return MapNoteToDto(note);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<NoteDto> FindNoteDtoById(int id)
        {
            Note note = await noteWorkflow.FindNoteById(id);
            return MapNoteToDto(note);
        }

        public async Task<NoteDto> OpenNote(int id)
        {
            Note note = await FindNoteById(id);
            await noteWorkflow.OpenNote(note);
            NoteDto newNoteDto = MapNoteToDto(note);

            return newNoteDto;
        }
        
        public string GenerateGuid()
        {
            return ShortId.Generate(false, false, 10);
        }

        public async Task<NoteDto> CreateNote(NoteDto noteDto)
        {
            Note note = MapDtoToNote(noteDto);
            Note createdNote = await noteWorkflow.CreateNote(note);
            return MapNoteToDto(createdNote);
        }

        private NoteDto MapNoteToDto(Note note)
        {
            return mapper.Map<NoteDto>(note);
        }

        private Note MapDtoToNote(NoteDto noteDto)
        {
            return mapper.Map<Note>(noteDto);
        }

        private async Task<Note> FindNoteById(int id)
        {
            Note note = await noteWorkflow.FindNoteById(id);
            return note;
        }
    }
}
