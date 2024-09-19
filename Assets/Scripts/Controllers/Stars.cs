using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private int currentStarIndex = 0;
    private float elapsedTime = 0f;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 currentLinePoint;

    // Update is called once per frame
    void Update()
    {
        if (starTransforms.Count < 2)
            return;

        if (startPoint == Vector3.zero && endPoint == Vector3.zero)
        {
            SetNextLinePoints();
        }

        DrawLineBetweenStars();
        CheckForNextLine();
    }

    void DrawLineBetweenStars()
    {
        elapsedTime += Time.deltaTime;

        float progress = elapsedTime / drawingTime;

        Vector3 direction = endPoint - startPoint;

        currentLinePoint = startPoint + direction * Mathf.Min(progress, 1f);

        Debug.Log($"Drawing line from {startPoint} to {currentLinePoint}");

        Debug.DrawLine(startPoint, currentLinePoint, Color.white);
    }

    void CheckForNextLine()
    {
        if (elapsedTime >= drawingTime)
        {
            currentStarIndex++;

            if (currentStarIndex >= starTransforms.Count - 1)
            {
                currentStarIndex = 0;
            }

            SetNextLinePoints();
            elapsedTime = 0f;
        }
    }

    void SetNextLinePoints()
    {
        startPoint = starTransforms[currentStarIndex].position;
        endPoint = starTransforms[currentStarIndex + 1].position;
    }
}
