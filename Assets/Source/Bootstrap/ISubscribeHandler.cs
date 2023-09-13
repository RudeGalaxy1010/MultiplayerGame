namespace Source.Bootstrap
{
    public interface ISubscribeHandler : ISubscribeOnlyHandler, IUnsubscribeOnlyHandler { }

    public interface ISubscribeOnlyHandler
    {
        void Subscribe();
    }

    public interface IUnsubscribeOnlyHandler
    {
        void Unsubscribe();
    }
}