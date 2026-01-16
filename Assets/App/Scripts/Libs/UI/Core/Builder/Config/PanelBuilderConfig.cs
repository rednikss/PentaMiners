using App.Scripts.Libs.UI.Core.Panel.View;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Builder.Config
{
    [CreateAssetMenu(fileName = "Panel Builder Config", menuName = "Config/Panel Builder", order = 0)]
    public class PanelBuilderConfig : ScriptableObject, IPanelProvider
    {
        [SerializeField] private PanelView[] panels;

        public T GetPanelView<T>() where T : PanelView
        {
            foreach (var panelView in panels)
            {
                if (panelView.GetType() != typeof(T)) continue;
                
                return panelView as T;
            }

            Debug.LogError($"Can't find the {typeof(T)}!");
            return null;
        }
    }
}