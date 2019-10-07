using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOrchestrator : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Map");
    }
}
