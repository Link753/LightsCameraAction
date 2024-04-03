using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EntityScript : MonoBehaviour
{
    int Stage, timesTeleported;
    bool isAggravated;
    State state;
    NavMeshAgent agent;
    Transform teleportpoints;
    RaycastHit hit;
    [SerializeField] Transform Player;
    [SerializeField] Transform[] telepoints;

    enum State
    {
        TELEPORT,
        OBSERVE,
        CHASE
    }
    // Start is called before the first frame update

    private void Awake()
    {
        isAggravated = false;
        state = new();
        state = State.TELEPORT;
        Stage = 0;
        timesTeleported = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
        if(Stage == 0)
        {
            transform.LookAt(Player);
        }
        else if(Stage == 1)
        {
            agent.SetDestination(Player.position);
        }

        switch (state)
        {
            case State.TELEPORT:
                break;
            case State.OBSERVE:
                transform.LookAt(Player);
                break;
            case State.CHASE:
                agent.SetDestination(Player.position);
                break;
        }

        if(timesTeleported > 2)
        {
            isAggravated = true;
            state = State.CHASE;
        }
        
        if(timesTeleported == 1)
        {
            state = State.OBSERVE;
        }
    }

    public void Teleport()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        teleportpoints = hit.collider.gameObject.transform.parent.GetChild(0);
        if(state != State.CHASE)
        {
            int rng = Random.Range(0, teleportpoints.childCount);
            transform.position = teleportpoints.GetChild(rng).position;
            timesTeleported++;
        }
    }

    public bool isAgro()
    {
        return isAggravated;
    }
}
