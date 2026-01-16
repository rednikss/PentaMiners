using App.Scripts.Libs.Infrastructure.Core.Context;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.Starter;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.EntryPoint
{
    public class SceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private MonoInstaller[] monoInstallers;
        
        private static ProjectContext _projectContext;
        
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init() => _projectContext = null;
        
        
        private void Awake()
        {
            _projectContext ??= ProjectContext.Build();
            
            var container = _projectContext.Container;
            
            foreach (var installer in monoInstallers)
            {
                installer.InstallBindings(container);
            }

            container.GetService<ISceneStarter>().StartScene();
        }
        
    }
}