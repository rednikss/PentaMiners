using App.Scripts.Libs.Core.Service.Container;
using UnityEngine;

namespace App.Scripts.Libs.Core.Service.Installer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void InstallBindings(ServiceContainer container);
    }
}