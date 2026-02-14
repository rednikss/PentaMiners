using App.Scripts.Libs.Patterns.Command.Default;

namespace App.Scripts.Libs.Patterns.Command.Value
{
    public interface ICommandCancelable : ICommand
    {
        public void Cancel();
    }
    
    public interface ICommandCancelable<in T>: ICommand<T>
    {
        public void Cancel(T value);
    }
}