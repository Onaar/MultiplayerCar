using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    [SerializeField]
    private WheelCollider wheelCollider;
    [SerializeField]
    private GameObject wheelBodies;
    [SerializeField]
    private bool frontWheel;

    public WheelCollider GetWheelCollider() => wheelCollider;
    public GameObject GetWheelBodies() => wheelBodies;
    public bool IsFrontWheel() => frontWheel;
}
