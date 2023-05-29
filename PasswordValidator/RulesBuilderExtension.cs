using System;

namespace CruxLabTT.PasswordValidator
{
    public static class RulesBuilderExtension
    {
        private static RulesBuilder NewRule(this RulesBuilder rulesBuilder, Func<string, ValidationResult> func)
        {
            rulesBuilder.AddRule(func);
            return rulesBuilder;
        }

        public static RulesBuilder CharMatches(this RulesBuilder rulesBuilder,
            char sign,
            int minMatchesCount,
            int maxMatchesCount)
        {
            ValidationResult charMatches(string str)
            {
                int matchesCount = 0;

                foreach (char c in str)
                {
                    if (c == sign)
                    {
                        ++matchesCount;
                    }
                }

                return matchesCount < minMatchesCount
                    ? new(false, $"Password contians less then {minMatchesCount} '{sign}' sign's")
                    : matchesCount > maxMatchesCount
                    ? new(false, $"Password contians more then {minMatchesCount} '{sign}' sign's")
                    : new(true, "Password contians exceptable count of '{sign}' sign's");
            }

            return rulesBuilder.NewRule(charMatches);
        }
    }
}