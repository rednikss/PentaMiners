using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Game.Level.Chain.Handler
{
    public interface IChainHandler
    {
        public List<Vector2Int> Handle();
    }
}