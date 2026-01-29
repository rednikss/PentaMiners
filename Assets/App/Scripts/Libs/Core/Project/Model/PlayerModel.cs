using App.Scripts.Libs.Core.Project.Model.Config;
using App.Scripts.Libs.Data.Provider;
using UnityEngine;

namespace App.Scripts.Libs.Core.Project.Model
{
    public class PlayerModel : MonoBehaviour, IPlayerModel
    {
        [SerializeField] private string path;

        private IDataProvider _dataProvider;
        
        private PlayerStatsConfig _data;
        
        public void Construct(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;

            InitData();
        }

        private void InitData()
        {
            if (!_dataProvider.Exists(path))
            {
                _data = new PlayerStatsConfig();
                _dataProvider.CreateData(_data, path);
                
                return;
            }
            
            _data = _dataProvider.GetData<PlayerStatsConfig>(path);
        }

        public int GetCurrentLevelCounter() => _data.CurrentLevel;

        public void IncreaseCurrentLevelCounter() => _data.CurrentLevel++;

        private void OnApplicationQuit()
        {
            _dataProvider.SetData(_data, path);
        }
    }
}