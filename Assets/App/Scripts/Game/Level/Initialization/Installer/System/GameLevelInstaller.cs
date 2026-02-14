using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Chain.Handler;
using App.Scripts.Game.Level.Chain.Removal;
using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Block.Drop;
using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Animator.Wave;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Game.Level.Core.Grid.Data.Blocks;
using App.Scripts.Game.Level.Core.Grid.Data.State;
using App.Scripts.Game.Level.Core.Spawner;
using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Services.Time.Tickable.Handler;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Installer.System
{
    public class GameLevelInstaller : MonoInstaller
    {
        [Header("Chain System")]
        
        [SerializeField] private Vector2Int[] _directions;

        [SerializeField, Min(2)] private int _chainLength;
        
        [SerializeField, Min(0)] private float _waveStepTime;
        
        [Header("Background")]
        
        [SerializeField] private Transform backgroundTransform;
        
        [SerializeField] private SpriteRenderer backgroundSprite;

        public override void InstallBindings(ServiceContainer container)
        {
            BuildLevelSystem(container);
            BuildLevelBuilder(container);
        }

        private void BuildLevelSystem(ServiceContainer container)
        {
            var grid = new LevelGrid();
            container.SetService<ILevelGrid, LevelGrid>(grid);
            
            var info = new GridInfo(grid);
            container.SetService<IGridInfo, GridInfo>(info);
            
            var gridBlocksData = new GridBlocksData(grid);
            container.SetService<IGridBlocksData, GridBlocksData>(gridBlocksData);
            
            var dropData = new GridDropData(grid, info);
            var block = new FallingBlock(grid, dropData, info);
            container.SetService<IFallingBlock, FallingBlock>(block);
            
            var spawner = new QueueSpawner(info, block);
            container.SetService<IQueueSpawner, QueueSpawner>(spawner);
            
            var chainHandler = new ChainHandler(grid, _directions, _chainLength);
            var animator = new WaveGridAnimator(grid, info, _waveStepTime);
            var removal = new ChainRemoval(chainHandler, grid, info, animator);
            container.SetService<IChainRemoval, ChainRemoval>(removal);
            
            var gridState = new GridState(grid);
            var handler = container.GetService<ITickableHandler>();
            var cycle = new LevelCycle(gridState, block, spawner, removal);
            container.SetService<ILevelCycle, LevelCycle>(cycle);
            handler.AddTickable(cycle);
        }

        private void BuildLevelBuilder(ServiceContainer container)
        {
            var backAdapter = new BackgroundAdapter(backgroundSprite, backgroundTransform);
            container.SetService<IBackgroundAdapter, BackgroundAdapter>(backAdapter);
            
            var builder = new LevelBuilder(container);
            container.SetService<ILevelBuilder, LevelBuilder>(builder);
        }
    }
}