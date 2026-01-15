using App.Scripts.Libs.UI.Core.Panel.View;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Container.Builder.Config
{
    [CreateAssetMenu(fileName = "Panel Builder Config", menuName = "Config/Panel Builder", order = 0)]
    public class PanelBuilderConfig : ScriptableObject
    {
        [SerializeField] private PanelView[] panels;

        public PanelView GetConfig<T>() where T : PanelView
        {
            foreach (var panelView in panels)
            {
                if (panelView.GetType() != typeof(T)) continue;
                
                return panelView;
            }

            return null;
        }
    }
}