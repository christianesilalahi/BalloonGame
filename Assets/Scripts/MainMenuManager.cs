using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace with your actual game scene name
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit(); // Won’t work in editor, but works in builds
    }
}
