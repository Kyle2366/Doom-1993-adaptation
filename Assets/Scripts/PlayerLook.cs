using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private JoystickControl inputSource;
    [SerializeField] GameObject player;

    [SerializeField] float sensitivity;

    private void Update()
    {
        player.transform.Rotate(((Vector3.up * inputSource.Direction.x)* sensitivity) * Time.deltaTime);
    }
}
