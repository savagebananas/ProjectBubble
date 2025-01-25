using System.Collections;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
	public float waitSeconds = 2.0f;

	public void StartDestroy(GameObject orig)
	{
		StartCoroutine(DestroyAfterWait(orig));
	}

	private IEnumerator DestroyAfterWait(GameObject original)
	{
		yield return new WaitForSeconds(waitSeconds);
		Destroy(gameObject);
		Destroy(original);
	}
}
