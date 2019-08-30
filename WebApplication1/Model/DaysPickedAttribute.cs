using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    //This is used to ensure that at least one day is picked when creating a surf profile
    public class DaysPickedAttribute : ValidationAttribute, IClientModelValidator
    {

        protected override ValidationResult IsValid(object IsDayChosen, ValidationContext validationContext)
        {
            SurfProfile surfProfile = (SurfProfile)validationContext.ObjectInstance;

            if (surfProfile.GetNumberOfDays() < 1)              //Call on the method in the surf profile class
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
