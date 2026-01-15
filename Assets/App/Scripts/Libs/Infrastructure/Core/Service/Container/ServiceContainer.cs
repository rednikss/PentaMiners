using System;
using System.Collections.Generic;

namespace App.Scripts.Libs.Infrastructure.Core.Service.Container
{
    public class ServiceContainer
    {
        private readonly Dictionary<Type, IServiceContainer> _containers = new();

        public void SetServiceSelf<TService>(TService value)
        {
            SetService<TService, TService>(value);
        }

        public void SetService<TBind, TService>(TService value) where TService : TBind
        {
            var container = FindContainer<TBind>();

            container.SetService(value);
        }

        public TBind GetService<TBind>()
        {
            var container = FindContainer<TBind>();

            return container.GetService();
        }

        private Container<T> FindContainer<T>()
        {
            var typeBind = typeof(T);
            
            if (!_containers.TryGetValue(typeBind, out var container))
            {
                container = new Container<T>();
                _containers[typeBind] = container;
            }

            return container as Container<T>;
        }

        private class Container<TBind> : IServiceContainer
        {
            private TBind _value;

            public void SetService(TBind value) => _value = value;

            public TBind GetService() => _value;
        }
        
        private interface IServiceContainer
        {
        }
    }
}