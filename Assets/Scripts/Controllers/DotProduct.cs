using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngle;
    public float blueAnlge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float redRads = redAngle * Mathf.Deg2Rad;
        float blueRads = blueAnlge * Mathf.Deg2Rad;

        Vector3 redVector = new Vector3(Mathf.Cos(redRads), Mathf.Sin(redRads), 0);
        Vector3 blueVector = new Vector3(Mathf.Cos(blueRads), Mathf.Sin(blueRads), 0);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.blue);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dotProduct = redVector.x * blueVector.x * redVector.y * blueVector.y;
            if (Mathf.Abs(dotProduct) < float.Epsilon) dotProduct = 0;

            print($"<color=yellow><size=18>{dotProduct}</size></color>");
        }

    }
}
