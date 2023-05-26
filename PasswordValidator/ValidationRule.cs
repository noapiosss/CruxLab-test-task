using System;

namespace CruxLabTT.PasswordValidator
{
    public class ValidationRule
    {
        private readonly Func<string, ValidationResult> _rule;

        public ValidationRule(Func<string, ValidationResult> rule)
        {
            _rule = rule;
        }

        public bool IsValid(string password, out ValidationResult validationResult)
        {
            validationResult = _rule(password);
            return validationResult.IsValid;
        }
    }
}