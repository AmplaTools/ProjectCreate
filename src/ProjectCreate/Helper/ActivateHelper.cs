using System;

namespace AmplaTools.ProjectCreate.Helper
{
    public static class ActivateHelper
    {
        public static T Activate<T>() where T : new()
        {
            return new T();
        }

        public static object Activate(Type type)
        {
            ArgumentCheck.IsNotNull(type);
            return Activator.CreateInstance(type);
        }
    }
}