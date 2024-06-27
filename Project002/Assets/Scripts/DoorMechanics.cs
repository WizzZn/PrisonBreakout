using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorMechanics : MonoBehaviour
{
    public PlayerCollid instance;

    [SerializeField] TextMeshProUGUI keyText;
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
        keyText.text = keyHave.ToString() + "/" + keyNeed.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
            Destroy(gameObject.GetComponent<BoxCollider>());
            btControll.gameObject.SetActive(false);

        }
    }
}
