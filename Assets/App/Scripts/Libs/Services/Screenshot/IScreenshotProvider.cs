using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.Services.Screenshot
{
    public interface IScreenshotProvider
    {
        public UniTask<Texture2D> TakeScreenshot();
    }
}