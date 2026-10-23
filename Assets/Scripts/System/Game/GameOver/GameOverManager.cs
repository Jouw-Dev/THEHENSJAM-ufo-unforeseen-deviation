using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject player;

    private bool gameOver;

    private void Awake()
    {
        Time.timeScale = 1f;

        if(gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    public void GameOver() 
    {
        if(gameOver) return;

        gameOver = true;

        if(gameOverPanel != null) gameOverPanel.SetActive(true);

        if(player != null)
        {
            MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

            foreach(MonoBehaviour script in scripts)
            {
                if(script != null && !(script is PlayerHealth)) script.enabled = false;
            }
        }

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        Time.timeScale = 0f;
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
