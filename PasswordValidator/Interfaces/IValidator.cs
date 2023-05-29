namespace CruxLabTT.PasswordValidator.Interfaces
{
    public interface IValidator
    {
        void AddRule(IValidationRule rule);
        ValidationResult Validate(string password);
    }
}