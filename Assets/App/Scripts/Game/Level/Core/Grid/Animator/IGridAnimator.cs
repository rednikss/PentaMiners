using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Level.Core.Grid.Animator
{
    public interface IGridAnimator
    {
        public UniTask UpdateGrid();
    }
}