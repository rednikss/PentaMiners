using App.Scripts.Libs.Core.Service.Container;
using App.Scripts.Libs.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Core.Project.Context
{
    public class ProjectContext : MonoBehaviour
    {
        public ServiceContainer Container { get; private set; }
        
        [SerializeField] private MonoInstaller[] contextInstallers;

        private static bool _initialized;
        
        private void Construct()
        {
            Container = new ServiceContainer();

            foreach (var installer in contextInstallers)
            {
                installer.InstallBindings(Container);
            }
        }
        
        public static ProjectContext Build()
        {
            if (_initialized) return null;
            _initialized = true;
            
            var context = Resources.Load<ProjectContext>("Project Context");
            context = Instantiate(context);
            DontDestroyOnLoad(context);
                
            context.Construct();
            
            return context;
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init() => _initialized = false;
    }
}