using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
	public Rigidbody rb;
	public BubbleGun bubbleGun;

	Vector3 mousePosition;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        	bubbleGun.Fire();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
        	mousePosition = hit.point;
        }

    }

    private void FixedUpdate()
    {
    	Vector3 aimDirection = (mousePosition - rb.position).normalized;
    	float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    	rb.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

}
