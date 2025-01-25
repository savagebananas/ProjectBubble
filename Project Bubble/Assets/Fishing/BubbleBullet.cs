using System.Collections;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
	public GameObject bubbleTrap;
	public float waitSeconds = 2.0f;

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Fish")
    	{
    		Vector3 bubbleSize = other.transform.localScale;
    		StartCoroutine(BubbleTrap(other.transform.position, bubbleSize, other.gameObject));
    	}
    	else
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
