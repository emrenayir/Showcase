using System;
using UnityEngine;

namespace ObserverPattern
{
    public class PlayerNarrationSystem : MonoBehaviour,IObserver
    {
        [SerializeField] private Subject playerSubject;
        
        public void OnNotify(PlayerActions data)
        {
            Debug.Log("Player Narration System NOTIFIED its a " + data + "type of enemy.." );
        }

        private void OnEnable()
        {
            playerSubject.AddObserver(this);
        }

        private void OnDisable()
        {
            playerSubject.RemoveObserver(this);
        }
    }
}