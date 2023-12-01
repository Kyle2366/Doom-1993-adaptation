using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private JoystickControl inputSource;
    [SerializeField] CharacterController characterController;
    public float speed;
    Vector3 directon;
    public Rigidbody rb;
    public bool grounded = false;
    public float groundCheckDistance;

    private void Update()
    {
        directon = transform.forward * inputSource.Direction.z + transform.right * inputSource.Direction.x;
        GroundCheck();
       
    }

    private void FixedUpdate()
    {
        characterController.Move(directon * (speed / 20));
    }

    public void GroundCheck()
    {
        groundCheckDistance = (GetComponent<CharacterController>().height / 2);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            grounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            grounded = false;
            Debug.Log("Not Grounded");
            GetComponent<CharacterController>().Move(-transform.up / 10f);

        }
        

    }
}
