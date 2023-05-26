using System;
using System.Collections.Generic;

namespace CruxLabTT.PasswordValidator
{
    public class RulesBuilder
    {
        private readonly List<ValidationRule> _rules;

        public RulesBuilder()
        {
            _rules = new();
        }

        public void AddRule(Func<string, ValidationResult> rule)
        {
            _rules.Add(new(rule));
        }

        public PasswordValidator Build()
        {
            return new(_rules);
        }
    }
}