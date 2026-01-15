namespace App.Scripts.Libs.Extensions.LayerMask
{
    public static class LayerMaskExtension
    {
        public static bool IsLayerInMask(this UnityEngine.LayerMask mask, int layer)
        {
            return mask.value == (mask.value | (1 << layer));
        }
    }
}