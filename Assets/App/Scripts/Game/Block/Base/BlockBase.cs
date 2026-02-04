using App.Scripts.Libs.UI.Core.View.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Block.Base
{
    public abstract class BlockBase : MonoBehaviour, IDroppable
    {
        [SerializeField] private TweenConfig _dashConfig;
        
        [SerializeField] private Transform _transform;
        
        public void Move(Vector3 delta) => _transform.position += delta;

        public void SetPosition(Vector3 pos) => _transform.position = pos;

        public Vector3 GetPosition() => _transform.position;
        
        public UniTask DashToX(float x)
        {
            return _transform.DOMoveX(x, _dashConfig.Duration)
                .SetEase(_dashConfig.Ease)
                .SetLink(gameObject)
                .Play().ToUniTask();
        }
        
        public void SetScale(float diameter)
        {
            _transform.localScale = Vector3.one * diameter;
        }
        
        public abstract void OnDrop();
    }
}