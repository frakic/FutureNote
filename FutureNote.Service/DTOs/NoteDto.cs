using System;

namespace FutureNote.Service.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public NoteStatus Status { get; set; }
        public string Guid { get; set; }
        public DateTime SealedOn { get; set; }
        public DateTime SealedUntil { get; set; }
        public DateTime FirstRead { get; set; }
    }
}