using DataAnnotationsExample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAnnotationsExample.Validators
{
    public class InUniversityValidationAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext => base.RequiresValidationContext;

        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationObject = validationContext.ObjectInstance;
            /*
            if (validationObject is Student) {
                Student student = (Student)validationContext.ObjectInstance;
            }
            */

            Student student = (Student)validationContext.ObjectInstance;
            if (!student.UniversityStudent)
            {
                return new ValidationResult("Sorry you must be a student of the university in order to submit");
            }
            return ValidationResult.Success;
        }
    }
}
