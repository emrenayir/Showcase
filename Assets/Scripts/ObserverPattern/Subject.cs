using UnityEngine;
using System.Collections.Generic;

namespace ObserverPattern
{
    public abstract class Subject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(PlayerActions action)
        {
            _observers.ForEach((observer =>
            {
                observer.OnNotify(action);
            } ));
        }
    }
}