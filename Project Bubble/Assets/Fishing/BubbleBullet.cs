using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}
}
