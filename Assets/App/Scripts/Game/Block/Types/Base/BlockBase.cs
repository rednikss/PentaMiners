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

        public void Move(Vector3 delta) => _transform.position += delta;
        
        public void SetScale(float scale) => _transform.localScale = scale * Vector3.one;
        
        public void SetPosition(Vector3 pos) => _transform.position = pos;

        public Vector3 GetPosition() => _transform.position;
        
        public async UniTask DashToX(float x)
        {
            await _transform.DOMoveX(x, _dashConfig.Duration)
                .SetEase(_dashConfig.Ease)
                .SetUpdate(UpdateType.Manual)
                .SetLink(gameObject)
                .Play()
                .AsyncWaitForCompletion().AsUniTask();
        }
        
        public async UniTask DashToY(float y)
        {
            await _transform.DOMoveY(y, _dropConfig.Duration)
                .SetEase(_dropConfig.Ease)
                .SetUpdate(UpdateType.Manual)
                .SetLink(gameObject)
                .Play()
                .AsyncWaitForCompletion().AsUniTask();
        }

        public abstract void Return();
        
        public abstract void OnDrop();
    }
}