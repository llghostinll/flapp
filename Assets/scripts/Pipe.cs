using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Destroy pipe when it goes off screen
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}