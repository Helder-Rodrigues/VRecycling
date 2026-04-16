using Unity.VisualScripting;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    private float startTime;
    private float endTime;
    private bool isRunning = false;

    public static TimeKeeper Instance { get; private set; }

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // persist across scenes
        
        StartTimer();
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        endTime = Time.time;
        isRunning = false;
    }

    public float GetTime()
    {
        return isRunning ? Time.time - startTime : endTime - startTime;
    }
    
    public string GetFormattedTime()
    {
        float time = GetTime();

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        return $"{minutes:00}:{seconds:00}";
    }
}