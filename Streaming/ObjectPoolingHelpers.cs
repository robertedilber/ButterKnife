using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ButterKnife.Pooling
{
    public static class ObjectPoolingHelpers
    {
        public static GameObject[] GeneratePool(GameObject objectToInstantiate, int amountToPool)
        {
            GameObject[] pool = new GameObject[amountToPool];
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Object.Instantiate(objectToInstantiate);
                obj.SetActive(false);
                pool[i] = obj;
            }
            return pool;
        }

        public static T[] GeneratePool<T>(GameObject objectToInstantiate, int amountToPool)
        {
            T[] pool = new T[amountToPool];
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = Object.Instantiate(objectToInstantiate);
                obj.SetActive(false);
                pool[i] = obj.GetComponent<T>();
            }
            return pool;
        }

        public static GameObject GetObjectFromPool(this GameObject[] pool)
        {
            //Iterate in pool
            for (int i = 0; i < pool.Length; i++)
                if (!pool[i].activeSelf)
                    return pool[i];
            //If the entire pool is busy
            return null;
        }

        public static T GetObjectFromPool<T>(this T[] pool) where T : Component
        {
            //Iterate in pool
            for (int i = 0; i < pool.Length; i++)
                if (!pool[i].gameObject.activeSelf)
                    return pool[i].gameObject.GetComponent<T>();
            //If the entire pool is busy
            return null;
        }
    }
}
