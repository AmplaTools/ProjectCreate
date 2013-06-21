using System;

namespace AmplaTools.ProjectCreate.Editor.DependencyInjection
{
    public interface IApplication : IDisposable
    {
        void Start();
        void Exit();
    }
}