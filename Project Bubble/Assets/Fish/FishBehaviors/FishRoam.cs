using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FishRoam : State
{
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float speed;
    [SerializeField] private float maxRoamingDistance;
    [SerializeField] private float timeBetweenRoams;
    private bool searchingForPoint;

    private Vector3 nextRoamPosition;

    public override void OnStart()
    {
        SearchMovePoint();
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
            if (searchingForPoint == false)
            {
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

    /// <summary>
    /// Finds New Point to go to
    /// </summary>
    private void SearchMovePoint()
    {
        //if (searchingForPoint == false) return;


        //Debug.Log("location found: " + potentialLocation);
        nextRoamPosition = Search();
    }

    private Vector3 Search()
    {
        float randomX = Random.Range(-maxRoamingDistance * 5, maxRoamingDistance * 5);
        float randomY = Random.Range(-maxRoamingDistance, maxRoamingDistance);
        var potentialLocation = new Vector3(parent.transform.position.x + randomX, parent.transform.position.y + randomY, 0);

        if (Physics.CheckBox(potentialLocation, new Vector3(0.5f, 0.5f, 0.1f), Quaternion.identity, 7, QueryTriggerInteraction.Ignore) || potentialLocation.y > -0.5f)
        {
            potentialLocation = Search();
        }
        return potentialLocation;
    }

    private IEnumerator RoamingCooldown()
    {
        searchingForPoint = true;
        yield return new WaitForSeconds(timeBetweenRoams);
        SearchMovePoint();
        searchingForPoint = false;
    }
    #endregion
}
