using UnityEngine;

public class lerp : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Lerp((PointA.transform.position - PointB.transform.position).magnitude, PointB.transform.position.magnitude, 0.5f);
    }
}
