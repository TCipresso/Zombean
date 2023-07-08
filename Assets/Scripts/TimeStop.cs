using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeStop : MonoBehaviour
{
    public bool isTimeStopped = false;
    private float originalTimeScale;

    private void Start()
    {
        originalTimeScale = Time.timeScale;
    }

    public void ToggleTimeStop()
    {
        isTimeStopped = !isTimeStopped;

        if (isTimeStopped)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = originalTimeScale; 
        }
    }

    public IEnumerator StartStopTime()
    {
        ToggleTimeStop();
        yield return new WaitForSecondsRealtime(10f);
        ToggleTimeStop();
    }
}

