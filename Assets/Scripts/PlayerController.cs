using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DrivingScript driveScript;


    private void Start()
    {
        driveScript = GetComponent<DrivingScript>();
    }

    private void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");
        bool flip = Input.GetKeyDown(KeyCode.F);
        if (!RaceController.RACING) accel = 0;
        driveScript.Drive(accel, brake, steer);

        if (flip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
            gameObject.transform.position += new Vector3(0, 1, 0);
        }
    }
}
