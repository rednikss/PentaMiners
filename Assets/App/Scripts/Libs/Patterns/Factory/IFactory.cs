namespace App.Scripts.Libs.Patterns.Factory
{
    public interface IFactory<out T>
    {
        public T Create();
    }
}