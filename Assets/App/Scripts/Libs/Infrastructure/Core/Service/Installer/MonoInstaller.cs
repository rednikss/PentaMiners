using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Service.Installer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void InstallBindings(ServiceContainer container);
    }
}