using System;
using UnityEngine;
using ObserverPattern;
namespace Composition
{
    public class PlayerController : Subject
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Red"))
            {
                NotifyObservers(PlayerActions.Red);
            }
            else if (other.gameObject.CompareTag("Blue"))
            {
                NotifyObservers(PlayerActions.Blue);
            }
            else if (other.gameObject.CompareTag("Yellow"))
            {
                NotifyObservers(PlayerActions.Yellow);
            }
        }
    }
}