using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] int fishCount;
    [SerializeField] int rareFishCount;
    [SerializeField] private List<GameObject> fishes = new List<GameObject>();
    [SerializeField] private GameObject rareFish;

    private void Awake()
    {
        for (int i = 0; i < fishCount; i++)
        {
            var fish = Instantiate(fishes[Random.Range(0, fishes.Count)], new Vector3(Random.Range(-50, 50), Random.Range(-90, -10), 0), Quaternion.identity);
            fish.transform.parent = transform;
        }
        for (int i = 0; i < rareFishCount; i++)
        {
            var fish = Instantiate(rareFish, new Vector3(Random.Range(-5, 5), Random.Range(-90, -50), 0), Quaternion.identity);
            fish.transform.parent = transform;
        }
    }

}
