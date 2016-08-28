using System;

namespace Cake.SevenZip
{
    // Tells CodeAnalysis that this argument is being validated
    // to be not null. Great for guard methods.
    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
        // Internal so it doesn't conflict with the potential billion
        // other implementations of this attribute.
    }
}
