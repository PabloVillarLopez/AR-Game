using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoleTimerController : MonoBehaviour
{
    //DartTimer
    public static int moleMin;
    public static float moleSeg;
    public TMP_Text moleTimeText;

    public static float moleTimeLeft;
    public static bool moleTimerRunning = false;

    //DartMiniGameTimer
    public static int moleGameMin;
    public static float moleGameSeg;
    public TMP_Text moleMiniGameTimeText;

    public static float moleMiniGameTimeLeft;
    public static bool moleMiniGameTimerRunning = false;

    private void Awake()
    {
        moleMin = 0;
        moleSeg = (int)moleSpawner.moleWaitTime;

        moleGameMin = 0;
        moleGameSeg = moleSpawner.totalTimeOfGame;
        moleTimeText.gameObject.SetActive(false);
        moleMiniGameTimeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (moleSpawner.molesCreatedAlive > 0 && moleSpawner.moleMinigameRunning && moleTimerRunning)
        {
            moleTimeText.gameObject.SetActive(true);
            moleTimeLeft -= Time.deltaTime;
            if (moleTimeLeft <= 0)
            {
                moleTimerRunning = false;
            }
            int tiempoMin = Mathf.FloorToInt(moleTimeLeft / 60);
            int tiempoSeg = Mathf.FloorToInt(moleTimeLeft % 60);

            moleTimeText.text = string.Format("{00:00}:{01:00}", tiempoMin, tiempoSeg);
        }

        if (moleSpawner.molesCreatedAlive < 0)
        {
            moleTimeText.gameObject.SetActive(false);
        }

        if (moleSpawner.molesCreatedAlive > 0 && moleSpawner.moleMinigameRunning && moleMiniGameTimerRunning)
        {
            moleMiniGameTimeText.gameObject.SetActive(true);
            moleMiniGameTimeLeft -= Time.deltaTime;
            if (moleMiniGameTimeLeft <= 0)
            {
                moleTimerRunning = false;
            }
            int tiempoMin2 = Mathf.FloorToInt(moleMiniGameTimeLeft / 60);
            int tiempoSeg2 = Mathf.FloorToInt(moleMiniGameTimeLeft % 60);

            moleMiniGameTimeText.text = string.Format("{00:00}:{01:00}", tiempoMin2, tiempoSeg2);
        }

        if (!moleSpawner.moleMinigameRunning)
        {
            moleMiniGameTimeText.gameObject.SetActive(false);
            moleTimeText.gameObject.SetActive(false);
        }
    }
}
