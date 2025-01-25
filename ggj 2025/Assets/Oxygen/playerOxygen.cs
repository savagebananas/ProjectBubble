using UnityEngine;

public class playerOxygen : MonoBehaviour
{
	public float oxygen = 100.0f;
	public float maxOxygen = 100.0f;
	public oxygenBar OxygenBar;
	public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < 0)
        {
        	oxygen -= 1;
        	OxygenBar.fillAmount = oxygen / maxOxygen;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bubble")
        {
            oxygen += 20;
            if(oxygen > maxOxygen)
            {
                oxygen = maxOxygen;
            }
            OxygenBar.fillAmount = oxygen / maxOxygen;
        }
        Destroy(other.gameObject);
    }
}
