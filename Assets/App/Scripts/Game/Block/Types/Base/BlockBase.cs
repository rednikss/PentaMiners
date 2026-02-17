using App.Scripts.Libs.Configs.Animation;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Block.Types.Base
{
    public abstract class BlockBase : MonoBehaviour
    {
        [SerializeField] private TweenConfig _dashConfig;
        
        [SerializeField] private TweenConfig _dropConfig;
        
        [SerializeField] private Transform _transform;

        private Tweener _dashXTweener;
        
        private Tweener _dashYTweener;

        protected void Construct()
        {
            _dashXTweener = _transform.DOMoveX(0, _dashConfig.Duration)
                .SetEase(_dashConfig.Ease)
                .SetRecyclable(true)
                .SetLink(gameObject);

            _dashYTweener = _transform.DOMoveY(0, _dropConfig.Duration)
                .SetEase(_dropConfig.Ease)
                .SetRecyclable(true)
                .SetLink(gameObject);
        }
        
        public void Move(Vector3 delta) => _transform.position += delta;
        
        public void SetScale(float scale) => _transform.localScale = scale * Vector3.one;
        
        public void SetPosition(Vector3 pos) => _transform.position = pos;

        public Vector3 GetPosition() => _transform.position;
        
        public async UniTask DashToX(float x)
        {
            _dashXTweener.ChangeValues(GetPosition(), new Vector3(x, 0, 0)).Restart();
            await _dashXTweener.AwaitForComplete();
        }
        
        public async UniTask DashToY(float y)
        {
            _dashYTweener.ChangeValues(GetPosition(), new Vector3(0, y, 0)).Restart();
            await _dashYTweener.AwaitForComplete();
        }

        public virtual void Return()
        {
            _dashXTweener.Kill();
            _dashYTweener.Kill();
        }
        
        public abstract void OnDrop();
    }
}