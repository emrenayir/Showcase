using System;
using UnityEngine;

namespace Inheritance
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected string firstName;

        [SerializeField] protected float moveSpeed;

        [SerializeField] protected int startingHealth;

        private int _health;

        protected virtual void Update()
        {
            Debug.Log("Doing this because it's a character");
        }

        private void Awake()
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
            Destroy(gameObject);
        }
    }
}