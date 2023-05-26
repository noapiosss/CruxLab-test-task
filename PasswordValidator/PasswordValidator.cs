using System;
using System.Collections.Generic;
using System.Linq;
using CruxLabTT.PasswordValidator.Interfaces;

namespace CruxLabTT.PasswordValidator
{
    public class PasswordValidator : IValidator
    {
        private readonly List<ValidationRule> _validationRules;

        public PasswordValidator()
        {
            _validationRules = new();
        }

        public PasswordValidator(IEnumerable<ValidationRule> validationRules)
        {
            _validationRules = validationRules.ToList();
        }

        public PasswordValidator(RulesBuilder rulesBuilder)
        {
            _validationRules = rulesBuilder.Build();
        }

        public void AddRule(Func<string, ValidationResult> rule)
        {
            _validationRules.Add(new(rule));
        }

        public ValidationResult IsValid(string password)
        {
            foreach (ValidationRule rule in _validationRules)
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