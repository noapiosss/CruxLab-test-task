using System;

namespace CruxLabTT.PasswordValidator.Interfaces
{
    public interface IRulesBuilder
    {
        void AddRule(Func<string, ValidationResult> rule);
        PasswordValidator Build(); // should be abstract validator
    }
}