using TMPro;
using TrashScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TrashGroundSpawner trashGroundSpawner;
    
    public void ShowResult()
    {
        TimeKeeper.Instance.StopTimer();
        
        trashGroundSpawner.KillSpawn();
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        resultText.text = $"Congratulations! \nYou completed in: \n{TimeKeeper.Instance.GetFormattedTime()}";
    }
    
    public void OnRestartBtn()
    {
        //Kill All Singleton Scripts
        if (TrashManager.Instance != null)
            Destroy(TrashManager.Instance.gameObject);
        if (TrashGuide.Instance != null)
            Destroy(TrashGuide.Instance.gameObject);
        if (TreeManager.Instance != null)
            Destroy(TreeManager.Instance.gameObject);
        if (SpawnTrash.Instance != null)
            Destroy(SpawnTrash.Instance.gameObject);
        if (TimeKeeper.Instance != null)
            Destroy(TimeKeeper.Instance.gameObject);

        Tutorial.IsOn = false;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
