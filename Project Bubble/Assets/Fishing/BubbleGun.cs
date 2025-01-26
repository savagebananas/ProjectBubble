using UnityEngine;

public class BubbleGun : MonoBehaviour
{
	public GameObject bubbleBulletPrefab;
	public Transform firePoint;
	public float fireForce = 20.0f;



	public void Fire()
	{
		GameObject bubbleBullet = Instantiate(bubbleBulletPrefab, firePoint.position, firePoint.rotation);
		bubbleBullet.GetComponent<Rigidbody>().AddForce(firePoint.right * fireForce, ForceMode.Impulse);

	}
}
