using System;
using App.Scripts.Libs.Extensions.SerializeInterface;
using App.Scripts.Libs.UI.Core.Panel.View;
using App.Scripts.Libs.UI.Core.Panel.View.Config;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Scripts.Libs.UI.Builder.Config
{
    [CreateAssetMenu(fileName = "Panel Builder Config", menuName = "Config/Panel Builder", order = 0)]
    public class PanelBuilderConfig : ScriptableObject, IPanelProvider
    {
        [SerializeField] private PanelConfig[] panels;

        public PanelConfig GetPanelConfig<T>() where T : Object, IPanelView
        {
            foreach (var panel in panels)
            {
                if (panel.View.Value is not T) continue;
                
                return panel;
            }

            Debug.LogError($"Can't find the {typeof(T)}!");
            return null;
        }
    }

    [Serializable]
    public class PanelConfig
    {
        [field: SerializeField] public Serialized<IPanelView> View;
        
        [field: SerializeField] public PanelViewConfig Animator;
    }

}