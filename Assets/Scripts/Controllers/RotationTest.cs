using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float AngularSpeed = 45f;

    public float TargetAngle = 125f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.magenta);

        float currentRotation = transform.rotation.eulerAngles.z + 90;
        Debug.Log($"<color=yellow> <size=18> {currentRotation} </size> </color>");

        if(TargetAngle - currentRotation < 0)
        {
            if (currentRotation > TargetAngle)
                transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);

        }
        else
        {
            if (currentRotation < TargetAngle)
                transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }

        
    }

    public float StandardizeAngle (float inAngle)
    {
        inAngle %= 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
