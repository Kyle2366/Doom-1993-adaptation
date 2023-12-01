 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject interactButton1;
    public GameObject interactButton2;
    public GameObject interactButton3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerEnter(Collider col)
    {
        if (Door.gameObject.tag == "1")
        {
            if (col.gameObject.tag == "Player")
            {
                interactButton1.SetActive(true);
            }
        }  
        if (Door.gameObject.tag == "2")
        {
            if (col.gameObject.tag == "Player")
            {
                interactButton2.SetActive(true);
            }
        }  
        if (Door.gameObject.tag == "3")
        {
            if (col.gameObject.tag == "Player")
            {
                interactButton3.SetActive(true);
            }
        }
       
    }

    public void OnTriggerExit(Collider col)
    {
        if (Door.gameObject.tag == "1")
        {
            if (col.gameObject.tag == "Player")
            {
                interactButton1.SetActive(false);
            }
        }
        if (Door.gameObject.tag == "2")
        {
            if (col.gameObject.tag == "Player")
            {
                interactButton2.SetActive(false);
            }
        }
        if (Door.gameObject.tag == "3")
        {
            if (col.gameObject.tag == "Player")
            {
                interactButton3.SetActive(false);
            }
        }

    }

}
