using System.Collections;
using App.Scripts.Game.Block.Base;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Column
{
    public class LevelColumn : IEnumerable
    {
        private readonly BlockBase[] _blocks;

        private readonly Vector3 _position;

        private readonly float _columnStep;
            
        private int _currentHeight;
            
        public LevelColumn(int height, Vector3 position, float columnStep)
        {
            _blocks = new BlockBase[height];
            _columnStep = columnStep;
            _position = position;
        }
            
        public void Add(BlockBase block)
        {
            _blocks[_currentHeight++] = block;
            block.SetPosition(GetPosition(_currentHeight));
        }

        public void Set(BlockBase block, int i)
        {
            _blocks[i] = block;
            block.SetPosition(GetPosition(i));
                
            if (i > _currentHeight) _currentHeight = i;
        }

        public Vector3 GetPosition(float i)
        {
            return _position + _columnStep * i * Vector3.up;
        }
            
        public Vector3 GetStartPosition() => GetPosition(_blocks.Length + 1);
        
        public bool IsBlockDropped(BlockBase fallingBlock)
        {
            return fallingBlock.GetPosition().y <= GetPosition(_currentHeight + 1).y;
        }
        
        public IEnumerator GetEnumerator() => _blocks.GetEnumerator();
        
        public bool IsFull() => _currentHeight >= _blocks.Length;
    }
}