using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Swimming underwater and horizontal movement above water
/// Transition between two sections (very scuffed)
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool aboveWater;

    private bool inputEnabled = true;
    float inputX;
    float inputY;

    private float elapsedTime;
    [SerializeField] private float transitionDuration;
    private bool inTransition = false;

    // Visuals
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private Animator diverAnimator;

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        FlipPlayer();

        // Water
        if (!aboveWater)
        {
            if (inputEnabled)
            {
                Vector3 movement = new Vector3(inputX * speed * Time.deltaTime, inputY * speed * Time.deltaTime, 0);
                transform.position += movement;
            }

            if (transform.position.y >= 0.25 && !inTransition)
            {
                Debug.Log("water to surface");
                StartCoroutine(WaterToSurface(transitionDuration));
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / transitionDuration;
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0.5f, 0), percentageComplete);
            }
        }
        // Surface
        else
        {

            if (inputEnabled)
            {
                Vector3 aboveWaterMovement = new Vector3(inputX * speed * Time.deltaTime, 0, 0);
                transform.position += aboveWaterMovement;
            }

            // player pressed down while on the surface
            if (inputY < 0 && !inTransition)
            {
                Debug.Log("surface to water");
                StartCoroutine(SurfaceToWater(transitionDuration));
                elapsedTime += Time.deltaTime;
                float percentageComplete = elapsedTime / transitionDuration;
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -1.5f, 0), percentageComplete);
            }
        }
    }

    private IEnumerator SurfaceToWater(float s)
    {
        inTransition = true;
        inputEnabled = false;
        yield return new WaitForSeconds(s);
        aboveWater = false;
        inputEnabled = true;
        inTransition = false;
        elapsedTime = 0;
    }

    private IEnumerator WaterToSurface(float s)
    {
        inTransition = true;
        inputEnabled = false;
        yield return new WaitForSeconds(s);
        aboveWater = true;
        inputEnabled = true;
        inTransition = false;
        elapsedTime = 0;
    }

    private void FlipPlayer()
    {
        //Flip player on X-axis
        if (inputX == 1)
        {
            rend.flipX = false;
        }
        else if(inputX == -1)
        {
            rend.flipX = true;
        }

        diverAnimator.SetInteger("XDirection", (int) inputX);
        diverAnimator.SetInteger("YDirection", (int) inputY);

    }
    
}
