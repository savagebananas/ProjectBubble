using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] StateMachine stateMachine;
    [SerializeField] State capturedState;
    public bool isCaptured = false;
    public int value; // points player will get if captured
    public bool isLockedIn;
    public void CaptureFish()
    {
        if (!isCaptured) 
        {
            stateMachine.SetNewState(capturedState);
            isCaptured = true;
        }

    }


}
