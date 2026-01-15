using System;
using App.Scripts.Libs.UI.View.Element.Base;
using UnityEngine;

namespace App.Scripts.Libs.UI.View.Config
{
    [Serializable]
    public class AnimatedView<T> where T : MonoBehaviour
    {
        [field: SerializeField] public ElementView View;

        [field: SerializeField] public T Element;
    }
}