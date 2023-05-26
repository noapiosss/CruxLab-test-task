namespace CruxLabTT
{
    public struct PasswordConstraint
    {
        public char Sign { get; set; }
        public int MinMatchesCount { get; set; }
        public int MaxMatchesCount { get; set; }

        public PasswordConstraint(char sign, int min, int max)
        {
            Sign = sign;
            MinMatchesCount = min;
            MaxMatchesCount = max;
        }
    }
}