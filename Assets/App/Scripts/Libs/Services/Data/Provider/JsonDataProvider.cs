using System.IO;
using Newtonsoft.Json;

namespace App.Scripts.Libs.Services.Data.Provider
{
    public class JsonDataProvider : IDataProvider
    {
        private readonly string _dataSourcePath;
        
        public JsonDataProvider(string dataSourcePath)
        {
            _dataSourcePath = dataSourcePath;
        }

        public void CreateData<T>(T obj, string path)
        {
            var info = new FileInfo(GetFullPath(path));
            info.Directory?.Create();
            SetData(obj, path);
        }

        public bool Exists(string path)
        {
            return new FileInfo(GetFullPath(path)).Exists;
        }

        public T GetData<T>(string path)
        {
            var str = File.ReadAllText(GetFullPath(path));
            return JsonConvert.DeserializeObject<T>(str);
        }

        public void SetData<T>(T obj, string path)
        {
            var str = JsonConvert.SerializeObject(obj);
            File.WriteAllText(GetFullPath(path), str);
        }

        private string GetFullPath(string path)
        {
            return Path.Combine(_dataSourcePath, path);
        }
    }
}