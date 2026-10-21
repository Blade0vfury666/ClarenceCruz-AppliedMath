using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        pool.Clear();
    }

    public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeSelf == false && pool[i].name == prefab.name)
            {
                pool[i].transform.position = position;
                pool[i].transform.rotation = rotation;
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        GameObject newObject = Instantiate(prefab, position, rotation);
        newObject.name = prefab.name;
        pool.Add(newObject);
        return newObject;
    }

    public static void Despawn(GameObject obj)
    {
        obj.SetActive(false);
    }
}