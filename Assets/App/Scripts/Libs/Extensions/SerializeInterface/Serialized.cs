using System;
using UnityEngine;

namespace App.Scripts.Libs.Extensions.SerializeInterface
{
    [Serializable]
    public class Serialized<T> where T : class
    {
        [SerializeField] private Component _value;
        
        public T Value
        {
            get
            {
                if (_value == null)
                {
                    Debug.LogError($"{nameof(Serialized<T>)}.{nameof(_value)} is null");
                }
                
                return _value as T;
            }
        }
    }
}