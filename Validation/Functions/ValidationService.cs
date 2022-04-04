using SimpleFibonacci.Entities;
using System;

namespace SimpleFibonacci.Functions
{
    public class ValidationService
    {
        public static ValidationResult ValidateFiboIndex(string input)
        {
            int value;
            if (int.TryParse(input, out value))
            {
                if (value <= 0)
                    return new ValidationResult()
                    {
                        IsValid = false,
                        Message = "The entered value must be equal or higher than 1."
                    };

                return new ValidationResult()
                {
                    IsValid = true,
                    Message = "Ok."
                };
            }
            else
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    Message = "The entered value is not an integer."
                };
            }
        }

        public static ValidationResult ValidateRetryResponse(string input)
        {

            int value;
            if (int.TryParse(input, out value))
            {
                if (value != 1 && value != 2)
                    return new ValidationResult()
                    {
                        IsValid = false,
                        Message = "The entered value must be either '1' or '2'."
                    };

                return new ValidationResult()
                {
                    IsValid = true,
                    Message = "Ok."
                };
            }
            else
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    Message = "The entered value is not an integer."
                };
            }
        }

    }
    
}
