using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAssignment : MonoBehaviour
{

    public float speed = 0f;
    public Transform PlayerTransform;

    //mechanic #2
    public GameObject enemyBombPrefab;
    public float bombSpawnPos = 1f;

    public float bombCooldown = 12f;
    public float currentBombCooldown;

    public float distanceBetween;

    // Start is called before the first frame update
    void Start()
    {
        currentBombCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

        if (currentBombCooldown > 0)
        {
            currentBombCooldown -= Time.deltaTime;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, PlayerTransform.position);

        //Debug.Log("Distance to Player: " + distanceToPlayer);

        if (distanceToPlayer >= distanceBetween && currentBombCooldown <= 0)
        {
            SpawnBomb(); 
        }

    }

    private void FollowPlayer()
    {
        Vector3 direction = (PlayerTransform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

    }

    private void SpawnBomb()
    {

        Vector3 spawnPosition = transform.position - new Vector3(0, bombSpawnPos, 0);

        GameObject enemyBomb = Instantiate(enemyBombPrefab, spawnPosition, Quaternion.identity);

        BombMovement bombMovement = enemyBomb.GetComponent<BombMovement>();
        if (bombMovement != null)
        {
            bombMovement.playerTransform = PlayerTransform; 
        }

        Destroy(enemyBomb, 7f);

        currentBombCooldown = bombCooldown;

    }


}
