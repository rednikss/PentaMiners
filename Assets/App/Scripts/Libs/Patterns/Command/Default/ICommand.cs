namespace App.Scripts.Libs.Patterns.Command.Default
{
    public interface ICommand
    {
        public void Execute();
    }
    
    public interface ICommand<in T>
    {
        public void Execute(T value);
    }
}