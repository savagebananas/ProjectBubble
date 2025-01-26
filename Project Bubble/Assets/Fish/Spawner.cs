using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int fishCount;
    [SerializeField] int rareFishCount;
    [SerializeField] private List<GameObject> fishes = new List<GameObject>();
    [SerializeField] private GameObject rareFish;

    [SerializeField] int bubbleCount;
    [SerializeField] private GameObject bubble;


    [SerializeField] private float timeBeforeBubbleSpawn;
    private float timer;

    private void Awake()
    {
        timer = timeBeforeBubbleSpawn;


        for (int i = 0; i < fishCount; i++)
        {
            var fish = Instantiate(fishes[Random.Range(0, fishes.Count)], new Vector3(Random.Range(-50, 50), Random.Range(-120, -10), 0), Quaternion.identity);
            fish.transform.parent = transform;
        }
        for (int i = 0; i < rareFishCount; i++)
        {
            var fish = Instantiate(rareFish, new Vector3(Random.Range(-5, 5), Random.Range(-120, -60), 0), Quaternion.identity);
            fish.transform.parent = transform;
        }
        for (int i = 0; i < bubbleCount; i++)
        {
            var b = Instantiate(bubble, new Vector3(Random.Range(-50, 50), Random.Range(-120, -10), 0), Quaternion.identity);
            b.transform.parent = transform;
        }
    }

    private void Update()
    {
        if (timer <= 0)
        {
            var b = Instantiate(bubble, new Vector3(Random.Range(-50, 50), Random.Range(-110, -10), 0), Quaternion.identity);
            b.transform.parent = transform;
            timer = timeBeforeBubbleSpawn;
        }

        timer -= Time.deltaTime;
    }

}
