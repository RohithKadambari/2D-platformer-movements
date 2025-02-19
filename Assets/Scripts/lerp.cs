using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public float lerpDuration = 2f; 
    private float lerpTime = 0f;
    private bool movingToB = true;

    void Start()
    {
        
    }

    void Update()
    {
        
        lerpTime += Time.deltaTime / lerpDuration;

        if (lerpTime > 1f)
        {
            lerpTime = 0f; // Reset the lerp time
            movingToB = !movingToB; // Reverse the direction
        }

        
        if (movingToB)
        {
            transform.position = Vector3.Lerp(PointA.transform.position, PointB.transform.position, lerpTime);
        }
        else
        {
            transform.position = Vector3.Lerp(PointB.transform.position, PointA.transform.position, lerpTime);
        }
    }
}