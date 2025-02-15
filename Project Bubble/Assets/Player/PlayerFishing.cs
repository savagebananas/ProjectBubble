using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFishing : MonoBehaviour
{
	public BubbleGun bubbleGun;
    private SpriteRenderer gunRend;
    [SerializeField] private PlayerOxygen playerOxygen;

    [SerializeField] AudioClip shootSfx;
    [SerializeField] AudioSource shootSfxSource;

    private void Awake()
    {
        playerOxygen = GetComponent<PlayerOxygen>();
        gunRend = bubbleGun.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (PauseScreen.timePaused) return;

        if (Input.GetMouseButtonDown(0))
        {
        	bubbleGun.Fire();
            //AudioManager.instance.PlaySound("Shoot");
            shootSfxSource.PlayOneShot(shootSfx);
            playerOxygen.oxygen -= 5;
        }

        Vector2 center = new Vector2(Screen.width / 2,Screen.height / 2);
        Vector3 aimDirection = ((Vector2) Input.mousePosition - center).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        bubbleGun.transform.rotation = Quaternion.Euler(0, 0, aimAngle);
        if (aimDirection.x < 0) gunRend.flipY = true;
        else gunRend.flipY = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fish")
        {
            var fish = other.gameObject.GetComponent<Fish>();
            if (fish.isCaptured)
            {
                AudioManager.instance.PlaySound("CollectBubble");
                fish.GetComponentInChildren<FishCapture>().CollectBubble(transform);
                ScoreSystem.Instance.AddScore(fish.value);
            }
        }
    }

}
