using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FishRoam : State
{
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float speed;
    [SerializeField] private float maxRoamingDistance;
    [SerializeField] private float timeBetweenRoams;
    private bool once2;

    private Vector3 nextRoamPosition;

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        Roam();
    }

    #region Roaming To Random Points
    void Roam()
    {
        if (Vector3.Distance(parent.transform.position, nextRoamPosition) > 0.1)//if not at next roam position
        {
            MoveTowardsRoamPoint();
        }
        else
        {
            if (once2 == false)
            {
                once2 = true;

                StartCoroutine(RoamingCooldown());
            }
        }
    }

    void MoveTowardsRoamPoint()
    {
        parent.transform.position = Vector2.MoveTowards(parent.transform.position, nextRoamPosition, speed * 0.75f * Time.deltaTime);

        if (parent.transform.position.x < nextRoamPosition.x) //moving right
        {
            sprite.flipX = false;
        }
        if (parent.transform.position.x > nextRoamPosition.x) //moving left
        {
            sprite.flipX = true;
        }
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-maxRoamingDistance, maxRoamingDistance);
        float randomY = Random.Range(-maxRoamingDistance, maxRoamingDistance);
        nextRoamPosition = new Vector2(parent.transform.position.x + randomX, parent.transform.position.y + randomY);
    }

    private IEnumerator RoamingCooldown()
    {
        timeBetweenRoams = Random.Range(3f, 6f);
        yield return new WaitForSeconds(timeBetweenRoams);
        SearchWalkPoint();
        once2 = false;
    }
    #endregion
}
