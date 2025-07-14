using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // fungsi untuk mengakses scene
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void paused()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f; // Aktifkan kembali waktu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Keluar dari game..."); 
        Application.Quit(); // akan menutup aplikasi saat build
    }

}