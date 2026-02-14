using App.Scripts.Libs.Configs.Animation;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.Panel.View.Config
{
    [CreateAssetMenu(fileName = "Panel Config", menuName = "Config/View/Panel", order = 0)]
    public class PanelViewConfig : ScriptableObject
    {
        [field: SerializeField] public TweenConfig Show;
        
        [field: SerializeField] public TweenConfig Hide;
    }
}