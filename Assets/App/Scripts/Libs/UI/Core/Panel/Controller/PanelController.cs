using System;
using App.Scripts.Libs.UI.View.Element.Base;
using Cysharp.Threading.Tasks;
using Object = UnityEngine.Object;

namespace App.Scripts.Libs.UI.Core.Panel.Controller
{
    public abstract class PanelController : IDisposable
    {
        private readonly ElementView _panelView;

        protected PanelController(ElementView panelView)
        {
            _panelView = panelView;
        }

        public UniTask ShowAnimated() => _panelView.ShowAnimated();

        public UniTask HideAnimated() => _panelView.HideAnimated();

        public void Show() => _panelView.Show();

        public void Hide() => _panelView.Hide();

        public void Destroy()
        {
            Dispose();
            Object.Destroy(_panelView.gameObject);
        }

        public abstract void Dispose();
    }
}