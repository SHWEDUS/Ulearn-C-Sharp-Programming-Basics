using System;

namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            return (count % 10) switch
            {
                1 when count % 100 != 11 => "рубль",
                >= 2 and <= 4 when (count % 100 < 10 || count % 100 >= 20) => "рубля",
                _ => "рублей"
            };
        }
    }
}