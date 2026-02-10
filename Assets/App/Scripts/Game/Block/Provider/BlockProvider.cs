using System.Collections.Generic;
using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Game.Block.Types.Default;
using App.Scripts.Libs.Patterns.Factory;
using UnityEngine;

namespace App.Scripts.Game.Block.Provider
{
    public class BlockProvider : IBlockProvider
    {
        private readonly Dictionary<int, IFactory<BlockBase>> _blockPools = new();

        private readonly List<int> _colorsID = new();

        private const string Factory = "IFactory`1";
        
        public void AddBlock(int id, IFactory<BlockBase> factory)
        {
            if (factory.GetType().GetInterface(Factory) == typeof(IFactory<ColorBlock>))
            {
                _colorsID.Add(id);
            }
            
            _blockPools.Add(id, factory);
        }
        
        public BlockBase GetBlock(int blockID)
        {
            return _blockPools[blockID].Create();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public T GetBlock<T>() where T : BlockBase
        {
            if (typeof(T) == typeof(ColorBlock)) return GetRandomColorBlock() as T;
            
            foreach (var pair in _blockPools)
            {
                var factory = pair.Value;
                
                if (factory.GetType().GetInterface(Factory) == typeof(IFactory<T>))
                {
                    return pair.Value.Create() as T;
                }
            }
            
            Debug.LogError($"Can't find {nameof(IFactory<T>)}");
            
            return null;
        }

        private BlockBase GetRandomColorBlock()
        {
            var blockID = Random.Range(0,  _colorsID.Count);
            blockID = _colorsID[blockID];
            
            return _blockPools[blockID].Create();
        }
    }
}