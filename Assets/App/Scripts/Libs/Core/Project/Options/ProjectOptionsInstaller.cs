using App.Scripts.Libs.Patterns.Command.Default;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.Core.Project.Options
{
    public class ProjectOptionsInstaller : ICommand
    {
        private readonly int _targetFrameRate;

        public ProjectOptionsInstaller(int targetFrameRate)
        {
            _targetFrameRate = targetFrameRate;
        }

        public void Execute()
        {
            Application.targetFrameRate = _targetFrameRate;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}