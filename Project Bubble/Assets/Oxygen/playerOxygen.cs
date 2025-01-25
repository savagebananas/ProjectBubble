using UnityEngine;

public class playerOxygen : MonoBehaviour
{
	public float oxygen = 100.0f;
	public float maxOxygen = 100.0f;
	public oxygenBar OxygenBar;
	public GameObject player;
	public float decreaseSpeed = 1.0f;
	public float addOxygen = 20.0f;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < 0)
        {
        	oxygen -= decreaseSpeed;
        	OxygenBar.fillAmount = oxygen / maxOxygen;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bubble")
        {
            oxygen += addOxygen;
            if(oxygen > maxOxygen)
            {
                oxygen = maxOxygen;
            }
            OxygenBar.fillAmount = oxygen / maxOxygen;
        }
        Destroy(other.gameObject);
    }
}
