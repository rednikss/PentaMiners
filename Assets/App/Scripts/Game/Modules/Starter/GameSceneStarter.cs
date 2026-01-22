using App.Scripts.Game.Level.Loader;
using App.Scripts.Game.Modules.Background;
using App.Scripts.Game.UI.Controller;
using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.UI.Core.Container;
using UnityEngine;

namespace App.Scripts.Game.Modules.Starter
{
    public class GameSceneStarter : ISceneStarter
    {
        private readonly IPanelContainer _panelContainer;
        
        private readonly ILevelLoader _levelLoader;


        public GameSceneStarter(IPanelContainer panelContainer, ILevelLoader levelLoader)
        {
            _panelContainer = panelContainer;
            _levelLoader = levelLoader;
        }

        public void StartScene()
        {
            var panel = _panelContainer.GetPanel<GamePanelController>();
            panel.ShowAnimated();

            var level = _levelLoader.LoadLevel(0);

            for (var i0 = 0; i0 < level.Blocks.GetLength(0); i0++)
            for (var i1 = 0; i1 < level.Blocks.GetLength(1); i1++)
            {
                Debug.Log($"[{i0}, {i1}] = {level.Blocks[i0, i1].ToString()}");
            }
        }
    }
}