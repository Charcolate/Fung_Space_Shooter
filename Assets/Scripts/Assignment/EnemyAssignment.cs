using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssignment : MonoBehaviour
{

    public float speed = 0f;
    public Transform PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 direction = (PlayerTransform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

    }
}
