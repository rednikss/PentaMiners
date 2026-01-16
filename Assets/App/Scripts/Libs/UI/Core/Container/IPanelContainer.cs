using System;
using App.Scripts.Libs.UI.Core.Panel.Controller;

namespace App.Scripts.Libs.UI.Core.Container
{
    public interface IPanelContainer : IDisposable
    {
        public T GetPanel<T>() where T : PanelController;

        public bool HasPanel<T>() where T : PanelController;

        public void AddPanel(PanelController panel);

        public void RemovePanel(PanelController panel);
    }
}