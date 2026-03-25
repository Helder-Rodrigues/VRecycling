using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void PlayButtonAction()
    {
        // Start timer BEFORE switching scene
        if (TimeKeeper.Instance != null)
        {
            TimeKeeper.Instance.StartTimer();
        }

        SceneManager.LoadScene("CollectTrash");
    }
}
