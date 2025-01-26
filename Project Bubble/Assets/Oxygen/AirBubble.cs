using UnityEngine;
using UnityEngine.Rendering;

public class AirBubble : MonoBehaviour
{
    Animator animator;

    Transform player;

    public bool collectedByPlayer = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!collectedByPlayer) return;
        animator.SetBool("Shrink", true);
        transform.position = Vector3.MoveTowards(transform.position, player.position, 0.1f);
    }

    public void CollectBubble(Transform player)
    {
        this.player = player;
        collectedByPlayer = true;
    }
}
