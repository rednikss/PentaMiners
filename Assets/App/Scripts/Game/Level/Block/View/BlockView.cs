using UnityEngine;

namespace App.Scripts.Game.Level.Block.View
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Construct()
        {
            
        }

        public void Move(Vector3 delta)
        {
            _transform.position += delta;
        }
        
        public void SetSize(float diameter)
        {
            _transform.localScale = Vector3.one * diameter;
        }

        public void SetColor(Color newColor)
        {
            _spriteRenderer.color = newColor;
        }
    }
}