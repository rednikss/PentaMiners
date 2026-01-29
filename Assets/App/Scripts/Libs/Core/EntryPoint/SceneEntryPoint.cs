using App.Scripts.Libs.Core.EntryPoint.Starter;
using App.Scripts.Libs.Core.Project.Context;
using App.Scripts.Libs.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Core.EntryPoint
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