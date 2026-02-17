using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Libs.Patterns.ObjectPool;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Game.Block.Types.Default
{
    public class ColorBlock : BlockBase
    {
        [SerializeField] private SpriteRenderer _renderer;

        private IObjectPool<ColorBlock> _objectPool;
        
        public Color Color
        {
            get => _renderer.color;
            set => _renderer.color = value;
        }

        public void Construct(IObjectPool<ColorBlock> objectPool)
        {
            base.Construct();
            _objectPool = objectPool;
        }

        public override void Return()
        {
            base.Return();
            _objectPool.ReturnObject(this);
        }

        public override void OnDrop()
        {
            //обсёрвер.проверьИЕбани
        }
    }
}