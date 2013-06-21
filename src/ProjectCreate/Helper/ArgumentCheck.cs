using System;

namespace AmplaTools.ProjectCreate.Helper
{
    public static class ArgumentCheck
    {
        public static void IsNotNull(object param)
        {
            if (param == null)
            {
                throw new ArgumentNullException();
            }
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
            if (param == string.Empty)
            {
                throw new ArgumentException(@"Argument can't be an empty string");
            }
        }

        public static void IsNotEmpty(string param, string paramName)
        {
            if (param == string.Empty)
            {
                throw new ArgumentException(@"Argument can't be an empty string", paramName);
            }
        }


        public static void IsTypeOf<T>(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (!typeof (T).IsAssignableFrom(type))
            {
                string message = string.Format("{0} is not a {1}", type.FullName, typeof(T).FullName);
                throw new ArgumentException(message);
            }
        }
    }
}