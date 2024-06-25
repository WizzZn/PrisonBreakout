using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public PlayerCollid pc;
    

    [SerializeField] GameObject btControll;
    [SerializeField] int keyNeed;
    [SerializeField] int keyHave;
    [SerializeField] Animator DoorAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           btControll.gameObject.SetActive(true);
            Debug.Log("Work on");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            btControll.gameObject.SetActive(false);
            Debug.Log("Work off");
        }
    }
    public void btClick()
    {
        if (pc.key == keyNeed)
        {
            DoorAnim.SetBool("Open", true);
        }
    }
}
