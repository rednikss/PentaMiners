namespace App.Scripts.Libs.Data.Provider
{
    public interface IDataProvider
    {
        public void CreateData<T>(T obj, string path);
        
        public bool Exists(string path);
        
        public T GetData<T>(string path);
        
        public void SetData<T>(T obj, string path);
    }
}