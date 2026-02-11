using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Libs.Patterns.Command.Value;
using App.Scripts.Libs.Services.Screen;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.Commands.Dash
{
    public class BlockDashCommand : ICommand<Vector2>
    {
        private readonly IGridInfo _gridInfo;
        
        private readonly IFallingBlock _fallingBlock;
        
        private readonly IProjectScreen _projectScreen;

        public BlockDashCommand(IGridInfo gridInfo, IFallingBlock fallingBlock, IProjectScreen projectScreen)
        {
            _projectScreen = projectScreen;
            _gridInfo = gridInfo;
            _fallingBlock = fallingBlock;
        }

        public void Execute(Vector2 value)
        {
            var percent = value.x / _projectScreen.GetPixelSize().x;
            var columnID = (int)(percent * _gridInfo.GetSize().x);
            
            _fallingBlock.DashToColumn(columnID);
        }
    }
}