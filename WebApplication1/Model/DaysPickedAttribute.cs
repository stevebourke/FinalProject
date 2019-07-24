using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    public class DaysPickedAttribute : ValidationAttribute, IClientModelValidator
    {

        protected override ValidationResult IsValid(object IsDayChosen, ValidationContext validationContext)
        {
            Member member = (Member)validationContext.ObjectInstance;

            if (member.GetNumberOfDays() < 1)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-DaysPicked", GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return $"You must choose at least one day to attend!";
        }

    }
}
