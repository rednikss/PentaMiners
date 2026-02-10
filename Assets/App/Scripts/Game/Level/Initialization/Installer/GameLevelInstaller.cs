using App.Scripts.Game.Level.Background;
using App.Scripts.Game.Level.Chain.Handler;
using App.Scripts.Game.Level.Chain.Removal;
using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Animator.Wave;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Game.Level.Core.Spawner;
using App.Scripts.Game.Level.Initialization.Builder;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Services.Time.Tickable.Handler;
using UnityEngine;

namespace App.Scripts.Game.Level.Initialization.Installer
{
    public class GameLevelInstaller : MonoInstaller
    {
        [Header("Chain System")]
        
        [SerializeField] private Vector2Int[] _directions;

        [SerializeField, Min(2)] private int _chainLength;
        
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
            
            var data = new GridData(grid);
            container.SetService<IGridData, GridData>(data);
            
            var block = new FallingBlock(grid, data);
            container.SetService<IFallingBlock, FallingBlock>(block);
            
            var spawner = new QueueSpawner(data, block);
            container.SetService<IQueueSpawner, QueueSpawner>(spawner);
            
            var chainHandler = new ChainHandler(grid, _directions, _chainLength);
            var animator = new WaveGridAnimator(grid, data);
            var removal = new ChainRemoval(chainHandler, grid, data, animator);
            container.SetService<IChainRemoval, ChainRemoval>(removal);
            
            var cycle = new LevelCycle(data, block, spawner, removal);
            container.SetService<ILevelCycle, LevelCycle>(cycle);
            container.GetService<ITickableHandler>().AddTickable(cycle);
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