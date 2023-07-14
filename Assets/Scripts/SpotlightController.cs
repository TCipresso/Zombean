using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public float speed = 5.0f;
    public float minX = -10.0f;
    public float maxX = 10.0f;
    public float minZ = -10.0f;
    public float maxZ = 10.0f;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }

       
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);

        return new Vector3(x, transform.position.y, z); 
    }
}
