using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed = 3f;       
    public float distance = 10f;   

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.right * distance;
    }

    void Update()
    {
        // Decide which direction to move
        Vector3 destination = movingToTarget ? targetPos : startPos;

        // Move towards the destination
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // If reached destination, flip direction
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            movingToTarget = !movingToTarget;
        }
    }
}

