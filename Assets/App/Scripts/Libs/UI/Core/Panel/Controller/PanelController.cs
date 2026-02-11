using System;
using App.Scripts.Libs.UI.Core.Panel.View;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace App.Scripts.Libs.UI.Core.Panel.Controller
{
    public abstract class PanelController : IDisposable
    {
        private readonly PanelView _panelView;

        protected PanelController(PanelView panelView)
        {
            _panelView = panelView;
        }

        public UniTask ShowAnimated() => _panelView.PanelElement.ShowAnimated();

        public UniTask HideAnimated() => _panelView.PanelElement.HideAnimated();

        public void Show() => _panelView.PanelElement.Show();

        public void Hide() => _panelView.PanelElement.Hide();

        public void Destroy()
        {
            Dispose();
            Object.Destroy(_panelView.gameObject);
        }

        public abstract void Dispose();
    }
}