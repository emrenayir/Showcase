using Interfaces;
using Managers;
using UnityEngine;

namespace Core
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        private Color m_OriginalColor;
        private Renderer m_Renderer;
        public float lifeTime = 5f;

        private void OnEnable()
        {
            Invoke(nameof(DeactivateBullet), lifeTime);
        }
        private void OnDisable()
        {
            CancelInvoke(nameof(DeactivateBullet));
        }
        private void Awake()
        {
            m_Renderer = GetComponent<Renderer>();
            m_OriginalColor = m_Renderer.material.color;
        }
        private void OnCollisionEnter(Collision collision)
        {
            DeactivateBullet();
        }
        private void DeactivateBullet()
        {
            ObjectPooler.Instance.ReturnToPool(gameObject,"Bullet");
        }
        public void ResetObject()
        {
            m_Renderer.material.color = m_OriginalColor;
        }
        
    }
}