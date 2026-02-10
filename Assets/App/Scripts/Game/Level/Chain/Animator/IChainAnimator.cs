using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Level.Chain.Animator
{
    public interface IChainAnimator
    {
        public void Drop();
        
        public UniTask DropAnimated();
    }
}