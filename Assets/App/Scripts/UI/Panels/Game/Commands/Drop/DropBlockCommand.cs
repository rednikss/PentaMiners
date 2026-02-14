using App.Scripts.Game.Level.Core.Block;
using App.Scripts.Game.Level.Core.Grid.Data;
using App.Scripts.Libs.Patterns.Command.Default;
using App.Scripts.Libs.Patterns.Command.Value;
using UnityEngine;

namespace App.Scripts.UI.Panels.Game.Commands.Drop
{
    public class DropBlockCommand : ICommand<Vector2>
    {
        private readonly IGridInfo _gridInfo;
        
        private readonly IFallingBlock _fallingBlock;

        public DropBlockCommand(IGridInfo gridInfo, IFallingBlock fallingBlock)
        {
            _gridInfo = gridInfo;
            _fallingBlock = fallingBlock;
        }

        public void Execute(Vector2 value)
        {
            if (!IsValueValid(value)) return;
            
            var size = _gridInfo.GetSize();
            _fallingBlock.Move(size.y * Vector3.down);
        }

        private bool IsValueValid(Vector2 value)
        {
            return Mathf.Abs(value.y) > Mathf.Abs(value.x) && value.y < 0;
        }
    }
}