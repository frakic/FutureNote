using System;

namespace FutureNote.Entities.Entities
{
    public class Note
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