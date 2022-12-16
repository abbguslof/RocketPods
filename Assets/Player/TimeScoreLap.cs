using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScoreLap : MonoBehaviour
{
    private float TimeCount;
    private float LastTimeCount = 0;
    public int LapCount = 1;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private TMP_Text Lap;
    [SerializeField] private TMP_Text LapTimeLast;

    public string last = "null";
    public bool goal1 = false;
    public bool goal2 = false;
    void Update()
    {
        TimeCount += Time.deltaTime;
        TimeText.text = (Mathf.Round(TimeCount * 100f) / 100f).ToString();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Goal") && last != "Goal1")
        {
            goal1 = true;
            last = "Goal1";
        }
        if (collision.gameObject.CompareTag("Goal2") && last != "Goal2")
        {
            goal2 = true;
            last = "Goal2";
        }

        if (goal1 == true && goal2 == true)
        {
            if (LapCount <= 3)
            {
                LapCount += 1;
                goal1 = false;
                goal2 = false;

                LastTimeCount = TimeCount - LastTimeCount;

                Lap.text = "Lap " + LapCount.ToString() + "/3";
                LapTimeLast.text = "Last Lap: " + LastTimeCount.ToString();
            }
            else
            {            
                Application.Quit();
            }
        }

    }
}
