using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{


    public static PlayerCollid instance = new PlayerCollid();
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
        keyHave = instance.key;
        Debug.Log(keyHave+ "KeyHave");
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           btControll.gameObject.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            btControll.gameObject.SetActive(false);
        }
    }
    public void btClick()
    {
        if (keyNeed == keyHave)
        {
            DoorAnim.SetBool("Open", true);
        }
    }
}
