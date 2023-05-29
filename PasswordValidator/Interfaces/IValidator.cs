namespace CruxLabTT.PasswordValidator.Interfaces
{
    public interface IValidator
    {
        ValidationResult IsValid(string password);
    }
}