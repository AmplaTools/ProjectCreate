using System;
using System.Windows.Forms;
using AmplaTools.ProjectCreate.Editor.DependencyInjection;
using AmplaTools.ProjectCreate.Editor.Events;
using AmplaTools.ProjectCreate.Editor.Messages;
using AmplaTools.ProjectCreate.Editor.Presenters;
using AmplaTools.ProjectCreate.Helper;

namespace AmplaTools.ProjectCreate.Editor
{
    public class WinFormsApplication : IApplication, IListener<ExitMessage>
    {
        private ApplicationContext applicationContext;
        private bool disposed = true;

        public WinFormsApplication(IMainPresenter mainPresenter, IoC ioc)
        {
            ArgumentCheck.IsNotNull(mainPresenter);
            ArgumentCheck.IsNotNull(ioc);

            ioc.EventAggregator.AddListener(this, true);

            Form mainForm = mainPresenter.MainView as Form;
            if (mainForm == null)
            {
                throw new InvalidOperationException("Presenter.View is not a Windows Form");
            }
            applicationContext = new ApplicationContext(mainForm);
            disposed = false;
        }

        void IListener<ExitMessage>.Handle(ExitMessage message)
        {
            CheckDisposed();
            Exit();
        }

        private void CheckDisposed()
        {
            if (disposed) throw new ObjectDisposedException(GetType().FullName);
        }

        public void Start()
        {
            CheckDisposed();
            Application.Run(applicationContext);
        }

        public void Exit()
        {
            CheckDisposed();
            DisposeContext();
        }

        private void DisposeContext()
        {
            if (applicationContext != null)
            {
                applicationContext.ExitThread();
                applicationContext.Dispose();
            }
            applicationContext = null;
            disposed = true;
        }

        public void Dispose()
        {
            DisposeContext();
        }
    }
}