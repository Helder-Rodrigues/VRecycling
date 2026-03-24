using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    private float startTime;
    private float endTime;
    private bool isRunning = false;

    public static TimeKeeper Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
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
        if (isRunning)
            return Time.time - startTime;
        else
            return endTime - startTime;
    }
}