using System;
using System.ComponentModel.DataAnnotations;

namespace FutureNote.Web.Models
{
    public sealed class CurrentOrFutureDateAttribute : ValidationAttribute
    {
        public CurrentOrFutureDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;

            if (date >= DateTime.Today)
            {
                return true;
            }
            return false;
        }
    }
}
