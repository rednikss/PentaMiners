using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Game.Level.Core.Grid.Data.Blocks;
using App.Scripts.Game.Level.Core.Spawner;
using App.Scripts.Game.Level.Core.Spawner.Queue;
using App.Scripts.Game.Level.Initialization.Config;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Services.Screen;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Builder
{
    public class LevelBuilder : ILevelBuilder
    {
        private readonly ServiceContainer _container;
        
        private readonly IBlockProvider _blockProvider;
        
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGridInfo _gridInfo;

        public LevelBuilder(ServiceContainer container)
        {
            _container = container;
            _blockProvider = _container.GetService<IBlockProvider>();
            _levelGrid = _container.GetService<ILevelGrid>();
            _gridInfo =  _container.GetService<IGridInfo>();
        }

        public ILevelCycle Build(LevelConfig levelConfig)
        {
            var screen = _container.GetService<IProjectScreen>();
            
            var unitSize = screen.GetUnitSize();
            var scale = unitSize.x / levelConfig.GetWidth();
            
            var gridHeight = Mathf.CeilToInt(unitSize.y / scale);
            var gridSize = new Vector2Int(levelConfig.GetWidth(), gridHeight);
            
            var pos = screen.GetWorldByPercent(Vector2.zero);
            
            _blockProvider.SetBlockScale(scale);
            _levelGrid.Init(gridSize);
            _gridInfo.Init(pos, scale);
            _container.GetService<IBackgroundAdapter>().Init(gridSize, pos, scale);
            
            var queue = BuildBlockQueue(levelConfig);
            _container.GetService<IQueueSpawner>().Init(queue);
            
            var cycle = _container.GetService<ILevelCycle>();
            cycle.SetSpeed(levelConfig.TickSpeed);
            
            BuildBlocks(levelConfig);
            
            return cycle;
        }

        private IBlockQueue BuildBlockQueue(LevelConfig levelConfig)
        {
            var blocksData = _container.GetService<IGridBlocksData>();
            return new BlockQueue(_blockProvider, blocksData);
        }

        private void BuildBlocks(LevelConfig config)
        {
            for (var i = 0; i < config.GetWidth(); i++)
            for (var j = 0; j < config.GetHeight(); j++)
            {
                var id = config.Blocks[config.GetWidth() - 1 - j, i];
                
                if (id == 0) continue;
                
                var block = _blockProvider.GetBlock(id);  
                _levelGrid.SetBlock(block, i, j);
                
                var pos = _gridInfo.IndexToWorldPos(i, j);
                block.SetPosition(pos);
            }
        }
    }
}