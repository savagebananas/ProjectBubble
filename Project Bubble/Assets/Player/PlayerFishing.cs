using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFishing : MonoBehaviour
{
	public BubbleGun bubbleGun;
    [SerializeField] private PlayerOxygen playerOxygen;

	Vector3 mousePosition;

    private void Awake()
    {
        playerOxygen = GetComponent<PlayerOxygen>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        	bubbleGun.Fire();
            playerOxygen.oxygen -= 5;
        }

        Vector2 center = new Vector2(Screen.width / 2,Screen.height / 2);
        Vector3 aimDirection = ((Vector2) Input.mousePosition - center).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        bubbleGun.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

}
