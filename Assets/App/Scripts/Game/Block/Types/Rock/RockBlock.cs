using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Libs.Patterns.ObjectPool;

namespace App.Scripts.Game.Block.Types.Rock
{
    public class RockBlock : BlockBase
    {
        private IObjectPool<RockBlock> _objectPool;

        public void Construct(IObjectPool<RockBlock> objectPool)
        {
            _objectPool = objectPool;
        }


        public override void Return()
        {
            _objectPool.ReturnObject(this);
        }

        public override void OnDrop()
        {
        }
    }
}