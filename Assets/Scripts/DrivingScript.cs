using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingScript : MonoBehaviour
{
    public WheelScript[] wheels; //tu bêd¹ wszystkie nasze ko³a
    public float torque = 200; //moment obrotowy
    public float maxSteerAngle = 30; //maksymalny k¹t wychylenia
    public float maxBrakeTorque = 500; //moment hamowania
    public float maxSpeed = 150; //max prêdkoœæ
    public Rigidbody rb;
    public float currentSpeed; //aktualna prêdkoœæ

    public void Drive(float accel, float brake, float steer)
    {
        accel = Mathf.Clamp(accel, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
        brake = Mathf.Clamp(brake, 0, 1) * maxBrakeTorque;

        float thrustTorque = 0;
        if (currentSpeed < maxSpeed && currentSpeed > -maxSpeed) thrustTorque = accel * torque;
        foreach (WheelScript wheel in wheels)
        {
            wheel.GetWheelCollider().motorTorque = thrustTorque;
            if (wheel.IsFrontWheel())
            {
                wheel.GetWheelCollider().steerAngle = steer;
            }
            wheel.GetWheelCollider().brakeTorque = brake;
            Quaternion quat;
            Vector3 position;
            wheel.GetWheelCollider().GetWorldPose(out position, out quat);
            wheel.GetWheelBodies().transform.position = position;
            wheel.GetWheelBodies().transform.rotation = quat;
            currentSpeed = wheel.GetWheelCollider().rpm;
        }
    }
}
