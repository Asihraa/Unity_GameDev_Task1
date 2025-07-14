using UnityEngine;
using UnityEngine.SceneManagement;

public class FinisPoint : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject finishUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int point = GemsManager.instance.currentGem;

            bool canProceed = false;

            if (currentScene == 1 && point >= 35) // Level 1
                canProceed = true;
            else if (currentScene == 2 && point >= 40) // Level 2
                canProceed = true;
            else if (currentScene == 3 && point >= 50) // Level 3
                canProceed = true;

            if (canProceed)
            {
                // Reset point for next level
                GemsManager.instance.currentGem = 0;

                if (currentScene == 3)
                {
                    // jika ini level terakhir maka akan menampilkan finish UI
                    if (finishUI != null)
                    {
                        finishUI.SetActive(true);
                        Time.timeScale = 0f;
                    }
                }
                else 
                {
                    SceneManager.LoadScene(currentScene + 1);
                }
            }
            else
            {
                // Tampilkan GameOver UI
                if (gameOverUI != null)
                {
                    gameOverUI.SetActive(true);
                }

                // Optional: Freeze game
                Time.timeScale = 0f;
            }
        }
    }
}
