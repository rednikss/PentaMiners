namespace App.Scripts.Libs.Patterns.ObjectPool
{
    public interface IObjectPool<T>
    {
        public T Get();

        public void ReturnObject(T pooledObject);
    }
}