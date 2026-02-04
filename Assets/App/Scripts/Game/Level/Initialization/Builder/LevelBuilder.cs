using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Game.Level.Initialization.Config;
using App.Scripts.Libs.Services.Screen;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Builder
{
    public class LevelBuilder : ILevelBuilder
    {
        private readonly IProjectScreen _projectScreen;
        
        private readonly ILevelGrid _levelGrid;

        private readonly IGameManager _gameManager;
        
        private readonly IBackgroundAdapter _backgroundAdapter;

        private readonly IBlockProvider _blockProvider;

        public LevelBuilder(IProjectScreen projectScreen, ILevelGrid levelGrid,
            IBackgroundAdapter backgroundAdapter, IBlockProvider blockProvider, IGameManager gameManager)
        {
            _projectScreen = projectScreen;
            _levelGrid = levelGrid;
            _backgroundAdapter = backgroundAdapter;
            _gameManager = gameManager;
            _blockProvider = blockProvider;
        }

        public IGameManager Build(LevelConfig levelConfig)
        {
            var unitSize = _projectScreen.GetUnitSize();
            var scale = unitSize.x / levelConfig.GetWidth();
            var gridHeight = Mathf.CeilToInt(unitSize.y / scale);
            var gridSize = new Vector2Int(levelConfig.GetWidth(), gridHeight);
            
            var pos = _projectScreen.GetPositionByPercent(Vector2.zero);
            
            _backgroundAdapter.SetGrid(gridSize, pos, scale);
            _levelGrid.Init(gridSize, pos, scale);
            _gameManager.SetSpeed(levelConfig.TickSpeed);
            
            BuildBlocks(levelConfig);
            
            return _gameManager;
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
            }
        }
    }
}