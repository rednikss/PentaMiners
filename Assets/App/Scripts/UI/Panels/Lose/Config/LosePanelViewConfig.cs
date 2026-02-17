using App.Scripts.Libs.UI.Core.Panel.View.Config;
using UnityEngine;

namespace App.Scripts.UI.Panels.Lose.Config
{
    [CreateAssetMenu(fileName = "Lose Panel Config", menuName = "Config/View/Panel/Lose", order = 0)]
    public class LosePanelViewConfig : PanelViewConfig
    {
        [field: SerializeField] public float Rotation;
        
        [field: SerializeField, Min(0)] public float preAnimationPauseTime;
    }
}