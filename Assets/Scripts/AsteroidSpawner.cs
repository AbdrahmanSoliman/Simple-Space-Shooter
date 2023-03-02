using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 0.5f, Random.Range(0.2f, 0.7f));
    }


    private void SpawnAsteroid()
    {
        GameObject obj = Pool.singleton.Get("asteroid");
        if(obj != null)
        {
            obj.transform.position = new Vector3(Random.Range(-7f,7f),10, 0);
            obj.SetActive(true);
        }
    }
}
