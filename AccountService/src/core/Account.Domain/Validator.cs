using System;

namespace AccountApi.Domain
{
    public static class Validator
    {
        public static void ShouldNotBeNullOrEmpty(this string property, string propertyName, string className, string methodName = null)
        {
            if (string.IsNullOrWhiteSpace(property) == true)
                throw new ArgumentException($"The {propertyName} property can not be null or empty. Class : {className}, method: {methodName}.");
        }

        public static void ShouldBeAValidDate(this DateTime value, string propertyName, string className, string methodName)
        {
            if (value == DateTime.MinValue)
                throw new ArgumentException($"{propertyName}'s value can not be null. Class : {className} and method : {methodName}.");
        }
        public static void ShouldBeGreaterThan(this DateTime value, DateTime comparedTo, string propertyName, string className, string methodName)
        {
            if (value == DateTime.MinValue || value<=comparedTo)
                throw new ArgumentException($"{propertyName}'s value should be greater than value it's getting compared against. Class : {className} and method : {methodName}.");
        }
    }
}
