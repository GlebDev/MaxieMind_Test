using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager instance;
    public static SpawnManager Instane
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SpawnManager>();
            }
            return instance;
        }
    }
    [SerializeField] private GameObject[] ObjectsArr;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnMinX, spawnMaxX;
    [SerializeField] private float spawnY;

    public List<GameObject> SpawnedObjects;
    private Coroutine spawnCoroutine = null;

    public void StartSpawn()
    {
        spawnCoroutine = StartCoroutine(DelayedSpawn());
    }

    public void StopSpawn()
    {
        if (spawnCoroutine != null) {
            StopCoroutine(spawnCoroutine);
        }
    }

    IEnumerator DelayedSpawn()
    {
        while (true) {
            if (spawnDelay <= 0)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(spawnDelay);
                SpawnRndObjectInRndPos();
            }
        }
    }

    private void SpawnRndObjectInRndPos() {
        if (ObjectsArr.Length == 0) {
            Debug.LogError("SpawnManager::SpawnRnadomObject() ObjectsArr is empty");
            return;
        }

        float rndX = Random.Range(spawnMinX, spawnMaxX);
        Vector3 rndPosition = new Vector3(rndX, spawnY, 0f);
        int rndIndex = Random.Range(0, ObjectsArr.Length);
        var obj = SimplePool.Spawn(ObjectsArr[rndIndex], rndPosition, Quaternion.identity);
        SpawnedObjects.Add(obj);
    }

    public void DespawnObject(GameObject obj)
    {
        if (SpawnedObjects.Contains(obj))
        {
            SpawnedObjects.Remove(obj);
        }
        SimplePool.Despawn(obj);
    }

    public void DespawnAllObject()
    {
        for (int i = 0; i < SpawnedObjects.Count; i++)
        {
            DespawnObject(SpawnManager.Instane.SpawnedObjects[i]);
        }
    }

}
