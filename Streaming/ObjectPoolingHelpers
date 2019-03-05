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
    }
}
