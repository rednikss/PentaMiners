using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Grid.Data.Blocks
{
    public interface IGridBlocksData
    {
        public IList<Color> GetRemainingColors();
    }
}