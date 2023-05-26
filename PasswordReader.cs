using System;
using System.IO;
using System.Text;

namespace CruxLabTT
{
    public class PasswordReader
    {
        private readonly string _password;

        private PasswordConstraint _passwordConstraint;

        public PasswordReader(string password, char sign, int min, int max)
        {
            _password = password;
            _passwordConstraint = new(sign, min, max);
        }

        public static int CountOfValidPasswords(string filePath)
        {
            int validPasswordsCount = 0;
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                using StreamReader streamReader = new(fileStream, Encoding.UTF8, true, 128);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!TryParseLine(line, out PasswordReader passwordReader))
                    {
                        continue;
                    }

                    if (passwordReader.IsValid())
                    {
                        ++validPasswordsCount;
                    }
                }
            }

            return validPasswordsCount;
        }

        public static bool TryParseLine(string line, out PasswordReader passwordReader)
        {
            passwordReader = null;

            string[] split = line.Split(" ");
            if (split.Length != 3 || split[0].Length != 1)
            {
                return false;
            }

            try
            {
                char sign = split[0][0];

                string[] counts = split[1].Split("-");
                int min = Int32.Parse(counts[0]);
                int max = Int32.Parse(counts[1][..^1]);

                passwordReader = new(split[2], sign, min, max);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValid()
        {
            int matchesCount = 0;

            foreach (char c in _password)
            {
                if (c == _passwordConstraint.Sign)
                {
                    ++matchesCount;
                }
            }

            return _passwordConstraint.MinMatchesCount <= matchesCount &&
                matchesCount <= _passwordConstraint.MaxMatchesCount;
        }
    }
}