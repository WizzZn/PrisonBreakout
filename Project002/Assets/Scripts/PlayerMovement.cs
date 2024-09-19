using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    int shiftSpeed =1;
    [SerializeField] bool isMovementWorke;
    void Start()
    {
        
    }

   
    void Update()
    {
        Movement();
        ShiftMove();
        if (!Input.GetKey(KeyCode.RightShift) && isMovementWorke)
        {
            playerSpeed =3;
        }
    }
    void Movement()
    {
        float Horizon = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float Vertic = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.Translate( new Vector3(Horizon, 0, Vertic));
        if (Horizon == 0 && Vertic == 0)
        {
            isMovementWorke = false;
        }
        else
        {
            isMovementWorke = true;
        }
    }
    void ShiftMove()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && isMovementWorke)
        {
            playerSpeed = playerSpeed + shiftSpeed;
        }
       
    }
}
