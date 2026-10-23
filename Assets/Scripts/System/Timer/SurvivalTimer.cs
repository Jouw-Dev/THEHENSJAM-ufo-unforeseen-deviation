using UnityEngine;

public class SurvivalTimer : MonoBehaviour
{
    public float TimeSurvived { get; private set;}

    private bool isRunning = true;

    private void Update()
    {
        if(!isRunning) return;

        TimeSurvived += Time.deltaTime;
    }

    public void StopTimer() 
    {
        isRunning = false;
    }

    public void ResumeTimer() 
    {
        isRunning = true;
    }

}
