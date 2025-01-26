using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleBullet : MonoBehaviour
{
	public GameObject bubbleTrap;
	public float waitSeconds = 2.0f;

    [SerializeField] private Animator animator;

    private bool fishCaptured = false;
    private bool bubbleLocked = false;
    private float timer = 5;
    private Fish fish;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {
        if (bubbleLocked) return;
        if (fishCaptured)
        {
            if (fish.isLockedIn) animator.SetBool("Scale", true);

            // move bullet towards captured fish and lock to transform, disable all functionality of bubble
            transform.position = Vector3.MoveTowards(transform.position, fish.transform.position, 0.1f);
            
            if (Vector3.Distance(transform.position, fish.transform.position) < 0.01)
            {
                transform.parent = fish.transform;
                fish.GetComponentInChildren<FishCapture>().bubble = gameObject;
                fish.gameObject.GetComponent<Fish>().CaptureFish();
                bubbleLocked = true;
            }


        }
        else
        {
            timer -= Time.deltaTime;
        }

        // Destroy if bubble wanders for 5 seconds
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Fish" && !fishCaptured)
    	{
            if (other.gameObject.GetComponent<Fish>().isCaptured) return; 
            fish = other.gameObject.GetComponent<Fish>();
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            fishCaptured = true;
        }
        else if (other.gameObject.tag == "Ground")
    	{
    		Destroy(gameObject);
    	}
	}

    private IEnumerator BubbleTrap(Vector3 position, Vector3 size, GameObject fish)
    {

    	GameObject bubble = Instantiate(bubbleTrap, position, Quaternion.identity);
    	bubble.transform.localScale = size * 2;

    	DelayedDestroy destroy = bubble.AddComponent<DelayedDestroy>();
    	destroy.waitSeconds = waitSeconds;
    	destroy.StartDestroy(fish);

    	yield break;
    }
}
