using System.Collections.Generic;

namespace Source.Bootstrap
{
    public class Services
    {
        private static Services _instance;
        public static Services Container => _instance ??= new Services();

        private readonly List<ISubscribeOnlyHandler> _subscribeHandlers = new List<ISubscribeOnlyHandler>();
        private readonly List<IUnsubscribeOnlyHandler> _unsubscribeHandlers = new List<IUnsubscribeOnlyHandler>();
        public IReadOnlyList<ISubscribeOnlyHandler> SubscribeHandlers => _subscribeHandlers;
        public IReadOnlyList<IUnsubscribeOnlyHandler> UnsubscribeHandlers => _unsubscribeHandlers;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.ServiceInstance = implementation;

            if (implementation is ISubscribeOnlyHandler subscribeHandler)
            {
                _subscribeHandlers.Add(subscribeHandler);
            }

            if (implementation is IUnsubscribeOnlyHandler unsubscribeHandler)
            {
                _unsubscribeHandlers.Add(unsubscribeHandler);
            }
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
