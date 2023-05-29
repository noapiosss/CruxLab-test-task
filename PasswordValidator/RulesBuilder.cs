using System;
using System.Collections.Generic;
using CruxLabTT.PasswordValidator.Interfaces;

namespace CruxLabTT.PasswordValidator
{
    public class RulesBuilder : IRulesBuilder
    {
        private readonly List<IValidationRule> _rules;

        public RulesBuilder()
        {
            _rules = new();
        }

        public void AddRule(Func<string, ValidationResult> rule)
        {
            _rules.Add(new ValidationRule(rule));
        }

        public PasswordValidator Build() // should be abstract validator
        {
            return new PasswordValidator(_rules);
        }
    }
}