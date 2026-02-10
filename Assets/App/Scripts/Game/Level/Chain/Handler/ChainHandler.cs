using System.Collections.Generic;
using App.Scripts.Game.Block.Types.Default;
using App.Scripts.Game.Level.Core.Grid;
using UnityEngine;

namespace App.Scripts.Game.Level.Chain.Handler
{
    public class ChainHandler : IChainHandler
    {
        private readonly ILevelGrid _levelGrid;
        
        private readonly Vector2Int[] _directions;
        
        private readonly int _minChainLength;
        
        private Vector2Int _size;
        
        private HashSet<Vector2Int> _visited;
        
        public ChainHandler(ILevelGrid levelGrid, Vector2Int[] directions, int minChainLength)
        {
            _levelGrid = levelGrid;
            _minChainLength = minChainLength;
            _directions = directions;
        }

        public List<Vector2Int> Handle()
        {
            _visited = new HashSet<Vector2Int>();
            _size = _levelGrid.GetSize();
            
            return FindChainedBlocks();
        }

        private List<Vector2Int> FindChainedBlocks()
        {
            var chainedBlocks = new List<Vector2Int>();
            
            for (var i = 0; i < _size.x; i++)
            for (var j = 0; j < _size.y; j++)
            {
                var index = new Vector2Int(i, j);
                
                if (_visited.Contains(index) || !IsColorBlock(index))
                    continue;
                
                var chain = FindChainFrom(index);
                chainedBlocks.AddRange(chain);
            }
        
            return chainedBlocks;
        }

        private List<Vector2Int> FindChainFrom(Vector2Int index)
        {
            var chain = new List<Vector2Int>();
            var queue = new Queue<Vector2Int>();
            var targetColor = GetColor(index);
            
            _visited.Add(index);
            chain.Add(index);
            queue.Enqueue(index);
            
            while (queue.Count > 0)
            {
                var i = queue.Dequeue();
                foreach (var dir in _directions)
                {
                    var neighbor = i + dir;
                    
                    if (!IsIndexValid(neighbor) || _visited.Contains(neighbor) ||
                        !IsColorBlock(neighbor) || GetColor(neighbor) != targetColor) continue;
                    
                    _visited.Add(neighbor);
                    chain.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
            
            return chain.Count >= _minChainLength ? chain : new ();
        }

        private bool IsColorBlock(Vector2Int index)
        {
            var block = _levelGrid.GetBlock(index.x, index.y);
            
            return block is ColorBlock;
        }
        
        private Color GetColor(Vector2Int index)
        {
            var block = _levelGrid.GetBlock(index.x, index.y);
            var colorBlock = block as ColorBlock;
            
            return colorBlock!.Color;
        }

        private bool IsIndexValid(Vector2Int index)
        {
            return index.x >= 0 && index.x < _size.x && index.y >= 0 && index.y < _size.y;
        }
    }
}