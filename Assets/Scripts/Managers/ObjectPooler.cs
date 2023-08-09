using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class ObjectPooler : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
            public bool isExpandable;
            [HideInInspector] public GameObject parentObj;
        }

        public static ObjectPooler Instance;

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> PoolDictionary;
        public Dictionary<string, Pool> PoolReferenceDictionary;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            PoolDictionary = new Dictionary<string, Queue<GameObject>>();
            PoolReferenceDictionary = new Dictionary<string, Pool>();

            foreach (var pool in pools)
            {
                pool.parentObj = new GameObject(pool.tag);
                pool.parentObj.transform.SetParent(transform);
                var objectPool = new Queue<GameObject>();
                
                for (var i = 0; i < pool.size; i++)
                {
                    var obj = Instantiate(pool.prefab, pool.parentObj.transform, true);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                PoolDictionary.Add(pool.tag, objectPool);
                PoolReferenceDictionary.Add(pool.tag, pool); 
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!PoolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
                return null;
            }

            if (PoolDictionary[tag].Count == 0)
            {
                if (PoolReferenceDictionary[tag].isExpandable)
                {
                    var obj = Instantiate(PoolReferenceDictionary[tag].prefab, transform, true);
                    obj.transform.SetParent(PoolReferenceDictionary[tag].parentObj.transform);
                    obj.SetActive(false);
                    PoolDictionary[tag].Enqueue(obj);
                }
                else
                {
                    Debug.LogWarning("No objects left in the pool with tag " + tag + " and it is not expandable.");
                    return null;
                }
            }

            GameObject objectToSpawn = PoolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            return objectToSpawn;
        }
        
        public void ReturnToPool(GameObject objectToReturn, string _tag)
        {
            if (!PoolDictionary.ContainsKey(_tag))
            {
                Debug.LogWarning("Pool with tag " + _tag + " doesn't exist.");
                return;
            }

            objectToReturn.SetActive(false);
            var poolable = objectToReturn.GetComponent<IPoolable>();
            poolable.ResetObject();
            PoolDictionary[_tag].Enqueue(objectToReturn);
        }

    }
}