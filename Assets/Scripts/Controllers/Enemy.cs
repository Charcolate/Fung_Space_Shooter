using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform; 
    public float moveSpeed = 5f;      
    public float stopDistance = 3f;  
    public float randomOffsetRange = 20f; 

    private void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
        Vector3 direction = playerTransform.position - transform.position;

        Vector3 normalizedDirection = direction.normalized;

        float distance = direction.magnitude;

        Vector3 randomOffset = new Vector3(Random.Range(-randomOffsetRange, randomOffsetRange), Random.Range(-randomOffsetRange, randomOffsetRange),0f);

        Vector3 movementWithOffset = normalizedDirection + randomOffset;

        float movementFactor = 1;

        if (distance <= stopDistance)
        {
            movementFactor = -1;
        }
       
        transform.position += movementWithOffset.normalized * moveSpeed * Time.deltaTime * movementFactor;
    }
}
