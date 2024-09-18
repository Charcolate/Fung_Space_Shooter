using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float speed = 0f;

    public float MaxSpeed = 20f;
    public float AccelerationTime = 3f;
    public float acceleration;

    private float deceleration;
    public float DecelerationTime = 5f;

    void Update()
    {
        acceleration = MaxSpeed / AccelerationTime;

        deceleration = MaxSpeed / DecelerationTime;
        
        PlayerMovement();

    }

    public void PlayerMovement( )
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        if (movement.magnitude > 0)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Min(speed, MaxSpeed);
        }

        if (movement.magnitude == 0 && speed > 0)
        {
            speed -= deceleration * Time.deltaTime;
            speed = Mathf.Max(speed, 0);
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
