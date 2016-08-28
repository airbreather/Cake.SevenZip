using System;

namespace Cake.SevenZip
{
    internal static class Extensions
    {
        internal static T ValidateNotNull<T>([ValidatedNotNull] this T value, string paramName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return value;
        }
    }
}
