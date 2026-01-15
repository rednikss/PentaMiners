namespace App.Scripts.Libs.Patterns.Command.Value
{
    public interface ICommand<in T>
    {
        public void Execute(T value);
    }
}