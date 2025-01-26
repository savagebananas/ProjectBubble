using System.Threading;
using UnityEngine;

public class FishCapture : State
{
    [SerializeField] private State roamState;
    [SerializeField] private float captureDuration;
    private float timer;

    private bool collectedByPlayer;
    private Transform player;

    public GameObject bubble;
    

    public override void OnStart() 
    {
        timer = captureDuration;
    }

    public override void OnUpdate()
    {
        if (!collectedByPlayer)
        {
            timer -= Time.deltaTime;
            // Fish escaped
            if (timer < 0)
            {
                GameObject.Destroy(bubble);
                parent.GetComponent<Fish>().isCaptured = false;
                // SFX ??
                stateMachine.SetNewState(roamState);
            }
        }

        else
        {
            parent.GetComponent<Animator>().SetBool("Capture", true);
            transform.position = Vector3.MoveTowards(transform.position, player.position, 0.1f);
            AudioManager.instance.PlaySound("Points");
            Invoke(nameof(DestroyGameObject), 0.1f);
        }
    }


    

    public void CollectBubble(Transform player)
    {
        this.player = player;
        collectedByPlayer = true;
    }


    void DestroyGameObject()
    {
        Destroy(parent.gameObject);
    }
}
