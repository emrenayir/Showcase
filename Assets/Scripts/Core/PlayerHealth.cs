using Interfaces;
using UnityEngine;

namespace Core
{
    public class PlayerHealth : MonoBehaviour,IDamageable
    {
        public float startingHealth = 100f;
        private float m_CurrentHealth;

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }
        public void Damage(float damage)
        {
            m_CurrentHealth -= startingHealth;
        }

        private void Start()
        {
            m_CurrentHealth = startingHealth;
        }
    }
}
