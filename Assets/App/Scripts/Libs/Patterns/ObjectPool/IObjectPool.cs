namespace App.Scripts.Libs.Patterns.ObjectPool
{
    public interface IObjectPool<TObjectType>
    {
        public TObjectType Get();

        public void ReturnObject(TObjectType pooledObject);

        public void Clear(bool clearUsing);
    }
}