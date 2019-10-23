using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOrchestrator : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene("Map");
    }
}