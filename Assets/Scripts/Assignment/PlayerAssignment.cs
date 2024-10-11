using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssignment : MonoBehaviour
{
    public float speed;

    //mechanic #1
    public GameObject bombprefab;
    public float bombOffset;
    public float bombDisappear;

    private bool firstBombSpawned = false;
    private bool secondBombSpawned = false;

    public float radius;
    private GameObject firstBombTransform;
    public Vector3 secondBombScale = new Vector3(0.5f, 0.5f, 0f);

    public float radius2;
    public Vector3 thirdBombScale = new Vector3(0.25f, 0.25f, 0f);

    private List<GameObject> secondBombs = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        //mechanic #1
        firstBomb();

        if (firstBombSpawned)
        {
            secondBomb();
        }

        if (secondBombSpawned)
        {
            ThirdBomb();
        }

    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;

        transform.Translate(movement * speed * Time.deltaTime);

    }

    //mechanic #1
    private void firstBomb()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 bombPosition = transform.position + new Vector3(0f, bombOffset, 0f);
            firstBombTransform = Instantiate(bombprefab, bombPosition, Quaternion.identity);

            Destroy(firstBombTransform, bombDisappear);

            firstBombSpawned = true;
        }
    }

    private void secondBomb()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float angleStep = 360f / 6f;
            for (int i = 0; i < 6; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;

                float xOffset = Mathf.Cos(angle) * radius;
                float yOffset = Mathf.Sin(angle) * radius;

                Vector3 bombPosition = firstBombTransform.transform.position + new Vector3(xOffset, yOffset, 0f);
                GameObject secondBomb = Instantiate(bombprefab, bombPosition, Quaternion.identity);

                secondBombs.Add(secondBomb);

                secondBomb.transform.localScale = secondBombScale;

                Destroy(secondBomb, bombDisappear);

                secondBombSpawned = true;
            }
        }
    }

    private void ThirdBomb()
    {
        if (Input.GetMouseButtonDown(2))
        {
            float angleStep = 360f / 4f;

            foreach (GameObject secondBomb in secondBombs)
            {

                for (int i = 0; i < 4; i++)
                {
                    float angle = i * angleStep * Mathf.Deg2Rad;

                    float xOffset = Mathf.Cos(angle) * radius2;
                    float yOffset = Mathf.Sin(angle) * radius2;

                    Vector3 bombPosition = secondBomb.transform.position + new Vector3(xOffset, yOffset, 0f);
                    GameObject thirdBomb = Instantiate(bombprefab, bombPosition, Quaternion.identity);

                    thirdBomb.transform.localScale = thirdBombScale;

                    Destroy(thirdBomb, bombDisappear);
                }

            }
        }
    }
}

