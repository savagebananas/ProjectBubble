using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
	public Image fill; 
    public float speed = 5.0f;

    public float fillAmount {get; set; } = 1.0f;

    // Update is called once per frame
    void Update()
    {
       fill.fillAmount = Mathf.Lerp(fill.fillAmount, fillAmount, speed * Time.deltaTime);
    }
}
