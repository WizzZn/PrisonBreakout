using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class testenemy : MonoBehaviour
{
    public Transform pathHold;
    public float speed;
    public float waitTime;
    public float turnSpeed = 90;
    public float rayLength;
    public LayerMask mask;

    private void Start()
    {
        if (pathHold.childCount == 0)
        {
            Debug.LogError("No waypoints assigned in the path.");
            return;
        }
        Vector3[] waypoints = new Vector3[pathHold.childCount];
        for(int i = 0; i <waypoints.Length; i++)
        {
            waypoints[i] = pathHold.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x,transform.position.y,waypoints[i].z);

        }
            StartCoroutine(FollowPath(waypoints));
       
    } 
    IEnumerator FollowPath(Vector3[] waypoints)
    {
       transform.position = waypoints[0];
        int targetWaypointsIntex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointsIntex];
        transform.LookAt(targetWaypoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

            if (transform.position == targetWaypoint)
            {
                targetWaypointsIntex = (targetWaypointsIntex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointsIntex];

                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            yield return null;
        }
    }
    IEnumerator TurnToFace( Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = Mathf.Atan2(dirToLookTarget.x, dirToLookTarget.z) * Mathf.Rad2Deg;

        while(Mathf.DeltaAngle(transform.eulerAngles.y,targetAngle) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetAngle, turnSpeed* Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;

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





