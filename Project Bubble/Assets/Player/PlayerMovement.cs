using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;



    void Update()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);

        transform.position += movement;
    }
}
