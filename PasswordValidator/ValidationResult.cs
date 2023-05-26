namespace CruxLabTT.PasswordValidator
{
    public readonly struct ValidationResult
    {
        public bool IsValid { get; init; }
        public string Message { get; init; }

        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}