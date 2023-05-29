namespace CruxLabTT.PasswordValidator.Interfaces
{
    public interface IValidationRule
    {
        bool IsValid(string password, out ValidationResult validationResult);
    }
}