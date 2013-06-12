using System;

namespace AmplaTools.ProjectCreate.Commands
{
    public interface ICommand : IDisposable
    {
        void Execute();
    }
}