using App.Scripts.Libs.Services.Screen;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.Services.Screenshot
{
    public class ScreenshotProvider : IScreenshotProvider
    {
        private readonly MonoBehaviour _coroutineRunner;
        
        private readonly IProjectScreen _projectScreen;

        public ScreenshotProvider(MonoBehaviour coroutineRunner, IProjectScreen projectScreen)
        {
            _coroutineRunner = coroutineRunner;
            _projectScreen = projectScreen;
        }

        public async UniTask<Texture2D> TakeScreenshot()
        {
            var active = RenderTexture.active;
            RenderTexture.active = null;
            
            var size = _projectScreen.GetPixelSize();
            var rect = new Rect(0, 0, size.x, size.y);
            var tex = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
            
            await UniTask.WaitForEndOfFrame(_coroutineRunner);
            tex.ReadPixels(rect, 0, 0, false);
            tex.Apply();
            
            RenderTexture.active = active;
            return tex;
        }
    }
}