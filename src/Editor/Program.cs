using System;
using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.DependencyInjection;

using Autofac;

namespace AmplaTools.ProjectCreate.Editor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (IoC ioc = new IoC())
            {
                ioc.Container.Resolve<IApplication>().Start();
            }
        }
    }
}
