using UnityEngine;
using UnityEngine.SceneManagement; // Include this to access scene management

public class GameManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1.5f;
    private float timer = 0f;
    private bool gameOver = false;

    void Update()
    {
        if (!gameOver)
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                SpawnPipe();
                timer = 0f;
            }
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(-1.5f, 2.5f);
        Vector2 spawnPosition = new Vector2(10f, randomY);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }

    public void EndGame()
    {
        gameOver = true; // Set gameOver to true
        Debug.Log("Game Over!"); // Log message for debugging
        Invoke("ReloadScene", 2f); // Reload the current scene after a short delay (optional)
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}