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
        OBSERVE,
        LOOKFORPLAYER,
        CHASE
    }
    // Start is called before the first frame update

    private void Awake()
    {
        isAggravated = false;
        state = new();
        state = State.OBSERVE;
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

        switch (state)
        {
            case State.OBSERVE:
                transform.LookAt(Player);
                break;
            case State.LOOKFORPLAYER:
                Physics.Raycast(transform.position, transform.forward, out hit);
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Player"))
                {
                    agent.SetDestination(transform.position);
                    transform.LookAt(Player);
                }
                else
                {
                    agent.SetDestination(Player.position);
                    transform.LookAt(Player);
                }
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
            state = State.LOOKFORPLAYER;
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
