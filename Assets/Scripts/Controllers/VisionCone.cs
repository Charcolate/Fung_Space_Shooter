using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public GameObject target;

    public float sightDistance;
    public float visionAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angleInRads = visionAngle * Mathf.Deg2Rad;

        Vector3 leftvector = new Vector3(Mathf.Cos(angleInRads), Mathf.Sin(angleInRads), 0) * sightDistance;
        Vector3 rightvector = new Vector3(Mathf.Cos(-angleInRads), Mathf.Sin(-angleInRads), 0) * sightDistance;

        Debug.DrawLine(transform.position, transform.position + leftvector, Color.cyan);
        Debug.DrawLine(transform.position, transform.position + rightvector, Color.cyan);

        if (target != null)
        {
            Vector3 vectortotarget = target.transform.position - transform.position;

            Debug.DrawLine(transform.position, transform.position + vectortotarget, Color.green);

            float targetdotProduct = Vector3.Dot(transform.right, vectortotarget.normalized);
            float visiondotProduct = Vector3.Dot(transform.right, leftvector.normalized);

            if (targetdotProduct >= visiondotProduct && vectortotarget.magnitude <= sightDistance)
            {
                print("<color=orange><size=18>Target spotted!</size></color>");
            }

        }

    }

    private void DrawVisionCone()
    {
        
    }
}
