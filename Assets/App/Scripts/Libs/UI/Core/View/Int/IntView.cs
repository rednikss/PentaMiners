using System.Text;
using App.Scripts.Libs.UI.Core.View.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using TMPro;
using UnityEngine;

namespace App.Scripts.Libs.UI.Core.View.Int
{
    public class IntView : MonoBehaviour
    {
        [SerializeField] private TweenConfig tweenConfig;
        
        [SerializeField] protected TextMeshProUGUI label;

        private readonly StringBuilder _builder = new();
        
        private int _value;

        private DOGetter<int> _getter;
        private DOSetter<int> _setter;

        public void Construct(int newValue = 0, string prefix = null, string postfix = null)
        {
            _builder.Append(prefix);
            _builder.Append(newValue);
            _builder.Append(postfix);
            
            label.text = _builder.ToString();
            
            _value = newValue;
            
            _getter = GetValue;
            _setter = SetValue;
        }

        public void SetValue(int newValue)
        {
            _builder.Replace(_value.ToString(), newValue.ToString());
            label.text = _builder.ToString();
            
            _value = newValue;
        }
        
        public UniTask SetValueAnimated(int newValue)
        {
            var t = DOTween.To(_getter, _setter, newValue, tweenConfig.Duration)
                .SetEase(tweenConfig.Ease)
                .SetLink(gameObject);

            return t.Play().ToUniTask();
        }
        
        public int GetValue() => _value;
    }
}