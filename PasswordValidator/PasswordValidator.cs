using System.Collections.Generic;
using System.Linq;
using CruxLabTT.PasswordValidator.Interfaces;

namespace CruxLabTT.PasswordValidator
{
    public class PasswordValidator : IValidator
    {
        private readonly List<IValidationRule> _validationRules;

        public PasswordValidator(IEnumerable<IValidationRule> validationRules)
        {
            _validationRules = validationRules.ToList();
        }

        public void AddRule(IValidationRule rule)
        {
            _validationRules.Add(rule);
        }

        public ValidationResult Validate(string password)
        {
            foreach (ValidationRule rule in _validationRules.Cast<ValidationRule>())
            {
                if (!rule.IsValid(password, out ValidationResult ValidationResult))
                {
                    return ValidationResult;
                }
            }

            return new(true, "");
        }
    }
}