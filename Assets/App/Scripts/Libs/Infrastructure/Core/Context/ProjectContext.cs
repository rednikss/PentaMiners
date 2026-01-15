using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Context
{
    public class ProjectContext : MonoBehaviour
    {
        public ServiceContainer Container { get; private set; }
        
        [SerializeField] 
        private MonoInstaller contextInstaller;

        private static bool _initialized;
        
        private void Construct()
        {
            Container = new ServiceContainer();
            contextInstaller.InstallBindings(Container);
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
    }
}