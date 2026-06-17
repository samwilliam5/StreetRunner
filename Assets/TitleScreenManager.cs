using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    // PlayGame() = called when Play button is clicked
    public void PlayGame()
    {
        // LoadScene = loads a different scene
        // "SampleScene" = the name of our game scene
        SceneManager.LoadScene("StreetRunner");
    }
}