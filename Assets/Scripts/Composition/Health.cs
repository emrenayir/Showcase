using System;
using UnityEngine;

namespace Composition
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int startingHealth;
        public int _health;

        public event Action OnDied;
        private void Start()
        {
            _health = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (OnDied != null)
            {
                OnDied();
            }
        }
    }
}