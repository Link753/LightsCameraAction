using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EntityScript : MonoBehaviour
{
    int Stage;
    NavMeshAgent agent;
    [SerializeField] Transform Player;
    [SerializeField] Transform[] telepoints;
    // Start is called before the first frame update

    private void Awake()
    {
        Stage = 0;
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
    }

    public void ChangeStage(int newStage)
    {
        Stage = newStage;
    }

    public void Teleport(Transform TargetPos)
    {
        int rng = Random.Range(0, TargetPos.childCount);
        Debug.Log(rng);
        transform.position = TargetPos.GetChild(rng).position;
    }
}