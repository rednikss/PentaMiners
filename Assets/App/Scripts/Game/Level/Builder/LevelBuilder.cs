using App.Scripts.Game.Level.Block.Controller;
using App.Scripts.Game.Level.Config;
using App.Scripts.Game.Modules.Background;
using App.Scripts.Libs.Patterns.ObjectPool;
using UnityEngine;

namespace App.Scripts.Game.Level.Builder
{
    public class LevelBuilder
    {
        private readonly Camera _sceneCamera;

        private readonly IBackgroundAdapter _backgroundAdapter;

        private readonly IObjectPool<BlockController> _blockPool;
        
        public void Build(LevelConfig levelConfig)
        {
            var width = levelConfig.GetWidth();
            
            var sceneHeight = (int) (width / _sceneCamera.aspect) + 1;
            var size = new Vector2(width, sceneHeight);
            
            var scale = _sceneCamera.orthographicSize * 2 * _sceneCamera.aspect / size.x;
            var pos = _sceneCamera.ScreenToWorldPoint(Vector3.zero);
            
            BuildBackground(size, scale, pos);

            BuildBlocks(levelConfig.Blocks, pos, scale / 2);
        }

        private void BuildBlocks(int[,] levelConfigBlocks, Vector3 pos, float scale)
        {
            pos += new Vector3(scale, scale);

            foreach (var configBlock in levelConfigBlocks)
            {
                    // if (block == Color.black) continue;
                    //
                    // var s = _blockPool.Get();
                    // //s.SetColor(block);
            }
        }

        private void BuildBackground(Vector2 size, float scale, Vector3 pos)
        {
            _backgroundAdapter.SetGridSize(size);
            _backgroundAdapter.SetGridScale(scale);
            _backgroundAdapter.SetPosition(pos);
        }
    }
}