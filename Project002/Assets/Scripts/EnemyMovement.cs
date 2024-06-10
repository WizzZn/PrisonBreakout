using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    public float dist;
    public NavMeshAgent agent;

    [SerializeField] Transform playerPoss;
    [SerializeField] Vector3 resetPoss;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        resetPoss = transform.position;
        agent = GetComponent<NavMeshAgent>();

    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPoss);
        // MoveTo();
        Navi();
    }
    void MoveTo()
    {
        
        dist = Vector3.Distance(playerPoss.position, transform.position);
        if (dist < 5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPoss.position, enemySpeed);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, resetPoss, enemySpeed);

        }
    }
    void Navi()
    {
        dist = Vector3.Distance(playerPoss.position, transform.position);
        if (dist < 15f)
        {
            agent.SetDestination(playerPoss.position);

        }
        else
        {
            agent.SetDestination(resetPoss);

        }
    }
}
