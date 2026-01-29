using UnityEngine;

namespace App.Scripts.Game.Block.Base.Color
{
    public class ColorBlock : BlockBase
    {
        [SerializeField] private SpriteRenderer _renderer;
        
        public void Construct()//какой-то блок обсёрвер хз
        {
            
        }

        public void SetColor(UnityEngine.Color color)
        {
            _renderer.color = color;
        }
        
        public override void OnDrop()
        {
            //обсёрвер.проверьИЕбани
        }
    }
}