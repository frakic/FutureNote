using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutureNote.Service.DTOs;
using FutureNote.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureNote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        //// GET: api/Notes
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/Notes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PATCH: api/Notes/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Open(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NoteDto noteDto = await noteService.FindNoteById((int)id);

            if (noteDto == null)
            {
                return NotFound();
            }

            try
            {
                NoteDto newNoteDto = await noteService.OpenNote((int)id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
