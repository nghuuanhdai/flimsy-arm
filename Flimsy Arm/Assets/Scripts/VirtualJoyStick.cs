using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoyStick : MonoBehaviour
{
    [SerializeField]
    private float normalizeDistance = 100;
    [SerializeField]
    private bool normalizedDeltaClamp = true;
    [SerializeField]
    private bool recenter = true;

    Vector3 touchDownPosition;
    Vector3 rawDelta;
    bool isTouching = false;
    private void Update() {
        if(Input.GetMouseButtonDown(0))
        {            
            touchDownPosition = Input.mousePosition;
            isTouching = true;
        }
        if(Input.GetMouseButton(0))
        {
            rawDelta = Input.mousePosition - touchDownPosition;
            if (recenter)
                touchDownPosition = Input.mousePosition - rawDelta.normalized*Mathf.Clamp(rawDelta.magnitude, 0, normalizeDistance);
        }
        if(Input.GetMouseButtonUp(0))
        {
            isTouching = false;
        }
    }

    public bool IsTouching => isTouching;
    public Vector3 RawDelta => rawDelta;
    public Vector3 NormalizedDelta {
        get{
            if(normalizedDeltaClamp)
                return RawDelta.normalized*Mathf.Clamp01(RawDelta.magnitude/normalizeDistance);
            return RawDelta/normalizeDistance;
        }
    }
}
