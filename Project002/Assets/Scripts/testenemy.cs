using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class testenemy : MonoBehaviour
{
    public Transform pathHold;
    public float speed;
    public float waitTime;
    private void Start()
    {
        Vector3[] waypoints = new Vector3[pathHold.childCount];
        for(int i = 0; i <waypoints.Length; i++)
        {
            waypoints[i] = pathHold.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x,transform.position.y,waypoints[i].z);

            StartCoroutine(FollowPath(waypoints));
        }

       
    } 
    IEnumerator FollowPath(Vector3[] waypoints)
    {
       transform.position = waypoints[0];
        int targetWaypointsIntex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointsIntex];

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            if (transform.position == targetWaypoint)
            {
                targetWaypointsIntex = (targetWaypointsIntex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointsIntex];

                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
    }
    
    private void Update()
    {

    }
    private void OnDrawGizmos()
    {
        Vector3 startPosition = pathHold.GetChild(0).position;
        Vector3 previousPosiion = startPosition;
        foreach (Transform waypoint in pathHold)
        {
            Gizmos.DrawSphere(waypoint.position,.3f);
            Gizmos.DrawLine(previousPosiion, waypoint.position);
            previousPosiion = waypoint.position;
        }
        Gizmos.DrawLine(previousPosiion,startPosition);
    }
}
