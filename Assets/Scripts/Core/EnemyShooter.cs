using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class EnemyShooter : BaseShooter
    {
        [SerializeField]
        private float minFireRate = 1f;  // Minimum ateş etme aralığı
        [SerializeField]
        private float maxFireRate = 3f;  // Maksimum ateş etme aralığı

        private void Start()
        {
            StartCoroutine(ShootDelay());
        }

        public override void Shoot()
        {
            var rotation = firePoint.rotation;
            rotation = Quaternion.Euler(Random.Range(-45, 45), rotation.eulerAngles.y, rotation.eulerAngles.z);
            firePoint.rotation = rotation;
            base.Shoot();
            if (base.bulletInstance != null)
            {
                bulletInstance.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }

        private IEnumerator ShootDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
                Shoot();
            }
        }
    }
}