using System;
using System.ComponentModel.DataAnnotations;

namespace FutureNote.Web.Models
{
    public class NoteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public NoteStatus Status { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string Guid { get; set; }

        [Display(Name = "Created on")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime SealedOn { get; set; }

        [Required]
        [Display(Name = "Sealed until")]
        [DataType(DataType.Date)]
        [CurrentOrFutureDate(ErrorMessage = "Pick a present or future date.")]
        [DisplayFormat(
            ApplyFormatInEditMode = true,
            ConvertEmptyStringToNull = false,
            DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime SealedUntil { get; set; }

        [Display(Name = "First read on")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime FirstRead { get; set; }
    }
}