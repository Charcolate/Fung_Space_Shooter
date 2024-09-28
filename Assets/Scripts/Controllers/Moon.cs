using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(5f, 50f, planetTransform);

    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        angle += speed * Time.deltaTime;

        if (angle >= 360f)
            angle -= 360f;

        float radians = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0) * radius;

        transform.position = target.position + offset;
    }
}
