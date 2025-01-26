using UnityEngine;

public abstract class State : MonoBehaviour
{
    public StateMachine stateMachine;
    public GameObject parent;
    public abstract void OnStart();
    public abstract void OnUpdate();
}
