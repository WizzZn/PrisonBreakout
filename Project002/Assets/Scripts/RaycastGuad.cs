using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGuad : MonoBehaviour
{
    public float rayLength;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      /*  Ray ray = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("hit");

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayLength, Color.green);
            Debug.Log("not hit");
        }

        if (Physics.BoxCast(transform.position,transform.position/2,Vector3.forward,Quaternion.identity,rayLength, mask))
        {

        }*/
    }
    private void OnDrawGizmos()
    {
        if (Physics.BoxCast(transform.position, transform.lossyScale / 2, Vector3.forward, out RaycastHit rayhit, transform.rotation, rayLength, mask))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.forward * rayhit.distance);
            Gizmos.DrawWireCube(transform.position + Vector3.forward * rayhit.distance, transform.lossyScale);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.forward * rayLength);
        }

    }
}
