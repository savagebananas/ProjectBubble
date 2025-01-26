using UnityEngine;

public class CircularPath : MonoBehaviour
{
    [SerializeField] Transform target; // target to circulate around
    [SerializeField] float speed = 5f;
    [SerializeField] float radius = 1f;
    [SerializeField] float angle = 0f;

    private void Start()
    {
        
    }

    void Update()
    {
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y + Mathf.Cos(angle) * 5;
        float z = target.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, z);
        angle += speed * Time.deltaTime;
    }
}
