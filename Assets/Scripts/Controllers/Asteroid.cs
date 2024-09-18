using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    private Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomPoint();
    }

    void Update()
    {
        MoveTowardsTarget();


        if (Vector3.Distance(transform.position, targetPoint) <= arrivalDistance)
        {
            ChooseRandomPoint();
        }
    }


    void ChooseRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * maxFloatDistance;
        randomDirection.z = 0;
        targetPoint = transform.position + randomDirection;
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
