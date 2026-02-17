using System;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Core.Panel.View.Config;
using UnityEngine;

namespace App.Scripts.Libs.UI.Builder.Config
{
    [CreateAssetMenu(fileName = "Panel Builder Config", menuName = "Config/Panel Builder", order = 0)]
    public class PanelBuilderConfig : ScriptableObject, IPanelProvider
    {
        [SerializeField] private PanelConfig[] panels;

        public PanelConfig GetPanelConfig<T>() where T : PanelView
        {
            foreach (var panel in panels)
            {
                if (panel.View is not T) continue;
                
                return panel;
            }

            Debug.LogError($"Can't find the {typeof(T)}!");
            return null;
        }
    }

    [Serializable]
    public class PanelConfig
    {
        [field: SerializeField] public PanelView View;
        
        [field: SerializeField] public PanelViewConfig Animator;
    }

}