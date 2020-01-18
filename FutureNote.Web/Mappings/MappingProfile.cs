using AutoMapper;
using FutureNote.Entities.Entities;
using FutureNote.Service.DTOs;
using FutureNote.Web.Models;

namespace FutureNote.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NoteDto, NoteViewModel>();
            CreateMap<NoteViewModel, NoteDto>();
            CreateMap<NoteDto, Note>();
            CreateMap<Note, NoteDto>();
        }
    }
}
