using App.Scripts.Game.Block.Provider;
using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Game.Level.Initialization.Config;
using App.Scripts.Libs.Services.Screen;

namespace App.Scripts.Game.Level.Initialization.Builder
{
    public class LevelBuilder : ILevelBuilder
    {
        private readonly IProjectScreen _projectScreen;

        private readonly IBackgroundAdapter _backgroundAdapter;

        private readonly IBlockProvider _blockProvider;
        
        private readonly IGameManager _gameManager;

        public LevelBuilder(IProjectScreen projectScreen, IBackgroundAdapter backgroundAdapter, 
            IBlockProvider blockProvider, IGameManager gameManager)
        {
            _projectScreen = projectScreen;
            _backgroundAdapter = backgroundAdapter;
            _blockProvider = blockProvider;
            _gameManager = gameManager;
        }

        public void Build(LevelConfig levelConfig)
        {
            var unitSize = _projectScreen.GetUnitSize();
            var scale = unitSize.x / levelConfig.GetWidth();
            var gridSize = unitSize / scale;

            _backgroundAdapter.SetGrid(gridSize, scale);
            
            _gameManager.InitGrid(levelConfig.GetWidth(), (int)gridSize.y, scale);
            _gameManager.SetSpeed(levelConfig.TickSpeed);
            
            BuildBlocks(levelConfig);

            _gameManager.SpawnFallingBlock();
        }

        
        private void BuildBlocks(LevelConfig config)
        {
            for (var i = 0; i < config.GetWidth(); i++)
            for (var j = 0; j < config.GetHeight(); j++)
            {
                var id = config.Blocks[config.GetWidth() - 1 - j, i];
                
                if (id == 0) continue;
                
                var block = _blockProvider.GetBlock(id);  
                _gameManager.SetBlock(block, i, j);
            }
        }
    }
}