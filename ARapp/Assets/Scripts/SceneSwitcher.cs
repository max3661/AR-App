using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Function to switch to FoundMarkers scene
    public void SwitchToFoundMarkersScene()
    {
        SceneManager.LoadScene("FoundMarkers");
    }

    // Function to switch back to main scene
    public void SwitchToMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
