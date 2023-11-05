namespace ObserverPattern
{
    public interface IObserver
    {
        public void OnNotify(PlayerActions data);
    }
}