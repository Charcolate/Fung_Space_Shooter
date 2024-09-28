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

    public GameObject powerUpPrefab;
    public Transform powerUpTransform;

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

        EnemyRadar (5f, 30);

        SpawnPowerups(5f, 6);

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

    public void EnemyRadar(float radius, int circlePoints)
    {
        Vector3 playerPosition = transform.position;

        if (circlePoints <= 0)
            return;

        float angle = (30 - circlePoints) * (360f / 30) * Mathf.Deg2Rad;

        Vector3 currentPointPos = new Vector3(
            playerPosition.x + Mathf.Cos(angle) * radius,
            playerPosition.y + Mathf.Sin(angle) * radius,
            playerPosition.z
        );

        angle += (360f / 30) * Mathf.Deg2Rad; // Move to the next point
        Vector3 nextPointPos = new Vector3(
            playerPosition.x + Mathf.Cos(angle) * radius,
            playerPosition.y + Mathf.Sin(angle) * radius,
            playerPosition.z
        );

        float distanceToEnemy = Vector3.Distance(playerPosition, enemyTransform.position);
        Color circleColor;

        if (distanceToEnemy <= radius)
        {
            circleColor = Color.red; 
        }
        else
        {
            circleColor = Color.green; 
        }

        Debug.DrawLine(currentPointPos, nextPointPos, circleColor);

        EnemyRadar(radius, circlePoints - 1);
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        if (numberOfPowerups <= 0 || powerUpPrefab == null)
        {
            return;
        }

        float angleStep = 360f / numberOfPowerups;
        for (int i = 0; i < numberOfPowerups; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0f);

            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity, powerUpTransform);
        }
    }


}
