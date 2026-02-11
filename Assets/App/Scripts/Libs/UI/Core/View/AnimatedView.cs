using System;
using App.Scripts.Libs.UI.Core.View.Element.Base;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.View
{
    [Serializable]
    public class AnimatedView<T> where T : MonoBehaviour
    {
        [field: SerializeField] public ElementView View;

        [field: SerializeField] public T Element;
    }
}