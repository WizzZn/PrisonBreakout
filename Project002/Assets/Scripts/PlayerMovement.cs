using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float Horizon = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float Vertic = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate( new Vector3(Horizon, 0, Vertic));
    }
}
