﻿using AutoMapper;
using FutureNote.Service.DTOs;
using FutureNote.Service.Interfaces;
using FutureNote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FutureNote.Web.Controllers
{
    public class NotesController : Controller
    {
        //private readonly FutureNoteContext _context;
        private readonly INoteService noteService;
        private readonly IMapper mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            this.noteService = noteService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string n)
        {
            if (n == null)
            {
                return View("Create");
            }

            NoteDto noteDto = await noteService.FindNoteByGuid(n);

            NoteViewModel note = MapNoteDtoToViewModel(noteDto);

            //var note = await _context.Notes.FirstOrDefaultAsync(m => m.Guid == n);

            if (note == null)
            {
                return NotFound();
            }

            if (note.SealedUntil > DateTime.Today)
            {
                return View("Sealed", note.SealedUntil);
            }

            if (note.Status == Models.NoteStatus.Open)
            {
                return View(note);
            }

            return View("Open", note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Open(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteDto noteDto = await noteService.FindNoteDtoById((int)id);

            if (noteDto == null)
            {
                return NotFound();
            }

            try
            {
                NoteDto newNoteDto = await noteService.OpenNote((int)id);
                return RedirectToAction(nameof(Index), new { n = newNoteDto.Guid });
            }
            catch
            {
                return Problem();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,SealedOn,SealedUntil,Status,Guid")] NoteViewModel noteViewModel)
        {
            noteViewModel.Guid = noteService.GenerateGuid();
            noteViewModel.SealedOn = DateTime.Today;
            noteViewModel.Status = Models.NoteStatus.Sealed;

            if (ModelState.IsValid)
            {
                NoteDto noteDto = MapViewModelToDto(noteViewModel);
                await noteService.CreateNote(noteDto);
                return RedirectToAction(nameof(Index), new { n = noteViewModel.Guid });
            }
            return View(noteViewModel);
        }

        private NoteViewModel MapNoteDtoToViewModel(NoteDto noteDto)
        {
            return mapper.Map<NoteViewModel>(noteDto);
        }

        private NoteDto MapViewModelToDto(NoteViewModel noteViewModel)
        {
            return mapper.Map<NoteDto>(noteViewModel);
        }
    }
}