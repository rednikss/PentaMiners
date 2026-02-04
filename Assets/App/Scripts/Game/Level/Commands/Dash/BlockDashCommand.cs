using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Manager;
using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.Services.Screen;
using UnityEngine;

namespace App.Scripts.Game.Level.Commands.Dash
{
    public class BlockDashCommand : ICommand<Vector2>
    {
        private readonly IProjectScreen _projectScreen;
        
        private readonly ILevelGrid _levelGrid;
        
        private readonly IGameManager _gameManager;

        public BlockDashCommand(IProjectScreen projectScreen, ILevelGrid levelGrid, IGameManager gameManager)
        {
            _projectScreen = projectScreen;
            _levelGrid = levelGrid;
            _gameManager = gameManager;
        }

        public void Execute(Vector2 value)
        {
            var percent = value.x / _projectScreen.GetPixelSize().x;
            var columnID = (int)(percent * _levelGrid.GetSize().x);
            
            _gameManager.DashBlock(columnID);
        }
    }
}