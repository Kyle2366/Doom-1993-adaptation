using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Door;
    public bool Open;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoors()
    {  
        if(Door.gameObject.tag ==  "1")
        {
            anim.Play("Door1");
        }
        if(Door.gameObject.tag ==  "2")
        {
            anim.Play("Door2");
        }
        if(Door.gameObject.tag ==  "3")
        {
            anim.Play("Door3");
        }
    
     
    }
  
}
