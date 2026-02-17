using App.Scripts.Game.Block.Types.Base;
using App.Scripts.Libs.Patterns.ObjectPool;

namespace App.Scripts.Game.Block.Types.Rock
{
    public class RockBlock : BlockBase
    {
        private IObjectPool<RockBlock> _objectPool;

        public void Construct(IObjectPool<RockBlock> objectPool)
        {
            base.Construct();
            _objectPool = objectPool;
        }


        public override void Return()
        {
            base.Return();
            _objectPool.ReturnObject(this);
        }

        public override void OnDrop()
        {
        }
    }
}