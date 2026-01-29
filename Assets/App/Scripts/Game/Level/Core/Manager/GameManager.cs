using App.Scripts.Game.Block.Base;
using App.Scripts.Game.Block.Provider;
using App.Scripts.Libs.Patterns.Command.Default;
using UnityEngine;

namespace App.Scripts.Game.Level.Core.Manager
{
    public class GameManager : IGameManager
    {
        private readonly ICommand _gameOverCommand;
        
        private readonly Vector3 _bottomLeftPosition;
        
        private readonly IBlockProvider _provider;

        private LevelColumn[] _columns;
        
        private float _speed;
        
        private BlockBase _fallingBlock;

        private int _currentColumn;

        public GameManager(Vector3 bottomLeftPosition, IBlockProvider provider, ICommand gameOverCommand)
        {
            _bottomLeftPosition = bottomLeftPosition;
            _provider = provider;
            _gameOverCommand = gameOverCommand;
            _speed = 1;
        }

        public void Tick(float deltaTime)
        {
            if (_fallingBlock is null) return;
            
            _fallingBlock.Move(_speed * deltaTime * Vector3.down);
            
            if (!_columns[_currentColumn].IsBlockDropped(_fallingBlock)) return;
            
            _columns[_currentColumn].Add(_fallingBlock);
            _fallingBlock.OnDrop();
            
            SpawnFallingBlock();
        }

        public void SetBlock(BlockBase block, int i, int j) => _columns[i].Set(block, j);

        public void SetSpeed(float speed) => _speed = speed;
        
        public void InitGrid(int width, int height, float scale)
        {
            _columns = new LevelColumn[width];
            
            var position = _bottomLeftPosition + new Vector3(0.5f, 0.5f, 0) * scale;
            
            for (var i = 0; i < _columns.Length; i++)
            {
                _columns[i] = new LevelColumn(this, height, position, scale);
                position += Vector3.right * scale;
            }
        }

        public void SetFallingBlockToColumn(int i)
        {
            _currentColumn = i;
            _fallingBlock.DashToX(_columns[i].Position.x);
        }
        
        public void SpawnFallingBlock()
        {
            _fallingBlock = _provider.GetNext();
            SetFallingBlockToColumn(_columns.Length / 2);
            _fallingBlock.SetPosition(_columns[_currentColumn].GetStartPosition());
        }
        
        private class LevelColumn
        {
            public readonly Vector3 Position;
            
            private readonly BlockBase[] _blocks;
            
            private readonly float _columnStep;
            
            private readonly GameManager _gameManager;
            
            private int _currentHeight;
            
            public LevelColumn(GameManager gameManager, int maxHeight, Vector3 position, float columnStep)
            {
                _gameManager = gameManager;
                _blocks = new BlockBase[maxHeight];
                _columnStep = columnStep;
                Position = position;
            }
            
            public void Add(BlockBase block)
            {
                _blocks[_currentHeight++] = block;
                block.SetPosition(GetPosition(_currentHeight));
                
                if (_currentHeight >= _blocks.Length)
                {
                    _gameManager._gameOverCommand.Execute();
                }
            }

            public void Set(BlockBase block, int i)
            {
                _blocks[i] = block;
                block.SetPosition(GetPosition(i));
                
                if (i > _currentHeight) _currentHeight = i;
            }

            public Vector3 GetPosition(float i)
            {
                return Position + _columnStep * i * Vector3.up;
            }
            
            public Vector3 GetStartPosition() => GetPosition(_blocks.Length + 1);
            

            public bool IsBlockDropped(BlockBase fallingBlock)
            {
                return fallingBlock.GetPosition().y <= GetPosition(_currentHeight + 1).y;
            }
        }
    }
}