using App.Scripts.Game.Block.Base;
using UnityEngine;

namespace App.Scripts.Game.Block.Types.Default
{
    public class ColorBlock : BlockBase
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        public void SetColor(Color color)
        {
            _renderer.color = color;
        }
        
        public override void OnDrop()
        {
            //обсёрвер.проверьИЕбани
        }
    }
}