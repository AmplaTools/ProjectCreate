using System.Collections.Generic;
using AmplaTools.ProjectCreate.Editor.Models;

namespace AmplaTools.ProjectCreate.Editor.Views
{
    public interface IEditorMenuView : IView
    {
        void InitializeMenu(List<MenuCommand> commands);
    }
}