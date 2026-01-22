using App.Scripts.Game.Player.Stats;
using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using App.Scripts.Libs.Data.Provider;
using UnityEngine;

namespace App.Scripts.Installer
{
    public class DataProviderInstaller : MonoInstaller
    {
        [SerializeField] private PlayerModel _model;

        public override void InstallBindings(ServiceContainer container)
        {
            var provider = new JsonDataProvider(Application.persistentDataPath);
            container.SetService<IDataProvider, JsonDataProvider>(provider);

            _model.Construct(provider);
            container.SetService<IPlayerModel, PlayerModel>(_model);
        }
    }
}