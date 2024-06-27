using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollid : MonoBehaviour
{
    public int key;
    public Animator DoorAnim;
   

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "Key")
        {
            other.gameObject.SetActive(false);
            key += 1;
        }
    }
}
