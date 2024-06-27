using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    public float dist;
    public NavMeshAgent agent;
    float enemyDist;

    [SerializeField] Transform playerPoss;
    [SerializeField] Vector3 resetPoss;
    [SerializeField] Light spotLight;

    // Start is called before the first frame update
    void Start()
    {
        spotLight.color = Color.green;
        enemyDist = 2.5f;
    }
    private void Awake()
    {
        resetPoss = transform.position;
        agent = GetComponent<NavMeshAgent>();

    }
    // Update is called once per frame
    void Update()
    {
     
        Navi();
    }
   
    void Navi()
    {
        dist = Vector3.Distance(playerPoss.position, transform.position);
        if (dist < enemyDist)
        {
            agent.SetDestination(playerPoss.position);
            spotLight.color = Color.red;
            enemyDist = 10f;
            transform.LookAt(playerPoss);

        }
        else if (dist > 10f)
        {
            agent.SetDestination(resetPoss);
            spotLight.color = Color.white;
            enemyDist = 2.5f;
        }
    }

}
