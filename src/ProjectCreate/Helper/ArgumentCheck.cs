using System;

namespace AmplaTools.ProjectCreate.Helper
{
    public static class ArgumentCheck
    {
        public static void IsNotNull(object param)
        {
            IsNotNull(param, null);
        }

        public static void IsNotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void IsNotEmpty(string param)
        {
            IsNotEmpty(param, null);
        }

        public static void IsNotEmpty(string param, string paramName)
        {
            if (param == string.Empty)
            {
                throw new ArgumentException(@"Argument can't be an empty string", paramName);
            }
        }

    }
}