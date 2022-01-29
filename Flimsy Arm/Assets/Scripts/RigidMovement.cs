using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(VirtualJoyStick))]
public class RigidMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;
    Rigidbody rb;
    VirtualJoyStick joyStick;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        joyStick = GetComponent<VirtualJoyStick>();
    }

    private void Update() {
        var inputV = joyStick.NormalizedDelta*(joyStick.IsTouching?1:0);
        if(joyStick.IsTouching)
            rb.velocity = new Vector3(inputV.x, 0, inputV.y)*speed;
        if(rb.velocity.magnitude > 0 && joyStick.IsTouching)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
