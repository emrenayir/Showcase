using Interfaces;
using Managers;
using UnityEngine;

namespace Core
{
    public class BaseShooter : MonoBehaviour,IShoot
    {
        public Transform firePoint;
        public float bulletSpeed = 10f;
        [HideInInspector] public GameObject bulletInstance;
        public virtual void Shoot()
        {
            bulletInstance = ObjectPooler.Instance.SpawnFromPool("Bullet",firePoint.position,firePoint.rotation);
            if (bulletInstance == null)
            {
                return;
            }
            Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }
        }
    }
}