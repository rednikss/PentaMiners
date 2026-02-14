using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.Configs.Animation
{
    [CreateAssetMenu(fileName = "Tween Config", menuName = "Config/View/Tween", order = 0)]
    public class TweenConfig : ScriptableObject
    {
        [field: SerializeField, Min(0)] 
        public float Duration = 0.25f;

        [field: SerializeField] 
        public Ease Ease = Ease.OutSine;
    }
}