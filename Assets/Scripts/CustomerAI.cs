using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public PositionManager positionManager;
    private NavMeshAgent agent;
    public Transform posToMove;

    private void Start()
    {
        positionManager = GameObject.Find("PositionManager").GetComponent<PositionManager>();
        agent  = GetComponent<NavMeshAgent>();
        ToTicketQueue();
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && posToMove)
        {
            RotateToTarget(posToMove);
        }
    }
    public void ToTicketQueue() // moves to empty ticket queue, sets posToMove to the current queue position
    {
        posToMove = positionManager.ReserveTicketQueue(this);
        agent.SetDestination(posToMove.position);
    }
    void RotateToTarget(Transform rot)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rot.rotation, 5 * Time.deltaTime);
    }
    public void DestroyAgent()
    {
        Destroy(this.gameObject);
    }
}