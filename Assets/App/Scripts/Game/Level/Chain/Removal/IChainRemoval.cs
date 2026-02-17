using System.Threading;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Game.Level.Chain.Removal
{
    public interface IChainRemoval
    {
        public UniTask Remove(CancellationToken ctsToken);
    }
}