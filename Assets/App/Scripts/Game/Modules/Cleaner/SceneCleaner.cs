using App.Scripts.Game.Level.Core.Cycle;
using App.Scripts.Game.Level.Core.Grid;
using App.Scripts.Libs.Services.Time.Tickable.Handler;

namespace App.Scripts.Game.Modules.Cleaner
{
    public class SceneCleaner : ISceneCleaner
    {
        private readonly ITickableHandler _tickableHandler;
        
        private readonly ILevelGrid _levelGrid;

        private readonly ILevelCycle _cycle;
        
        public SceneCleaner(ILevelGrid levelGrid, ILevelCycle cycle, ITickableHandler tickableHandler)
        {
            _levelGrid = levelGrid;
            _cycle = cycle;
            _tickableHandler = tickableHandler;
        }

        public void Clear()
        {
            _cycle.Stop();
            _tickableHandler.RemoveTickable(_cycle);
            
            var size = _levelGrid.GetSize();
            for (var i = 0; i < size.x; i++)
            for (var j = 0; j < size.y; j++)
            {
                _levelGrid.GetBlock(i, j)?.Return();
                _levelGrid.SetBlock(null, i, j);
            }
        }
    }
}