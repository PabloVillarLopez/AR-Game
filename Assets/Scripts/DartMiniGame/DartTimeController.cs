using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DartTimeController : MonoBehaviour
{
    //DartTimer
    public static int dartMin;
    public static int dartSeg;
    public TMP_Text dartTimeText;

    public static float dartTimeLeft;
    public static bool dartTimerRunning = false;

    //DartMiniGameTimer
    public static int gameMin;
    public static float gameSeg;
    public TMP_Text dartMiniGameTimeText;

    public static float dartMiniGameTimeLeft;
    public static bool dartMiniGameTimerRunning = false;

    private void Awake()
    {
        dartMin = 0;
        dartSeg = (int)dartSpawner.waitTime;

        gameMin = 0;
        gameSeg = dartSpawner.totalTimeOfGame;
        dartTimeText.gameObject.SetActive(false);
        dartMiniGameTimeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dartSpawner.dartsCreatedOnDartboard > 0 && dartSpawner.running && dartTimerRunning)
        {
            dartTimeText.gameObject.SetActive(true);
            dartTimeLeft -= Time.deltaTime;
            if (dartTimeLeft < 0)
            {
                dartTimerRunning = false;
            }
            int tiempoMin = Mathf.FloorToInt(dartTimeLeft / 60);
            int tiempoSeg = Mathf.FloorToInt(dartTimeLeft % 60);

            dartTimeText.text = string.Format("{00:00}:{01:00}", tiempoMin, tiempoSeg);
        }

        if (dartSpawner.dartsCreatedOnDartboard < 0)
        {
            dartTimeText.gameObject.SetActive(false);
        }

        if (dartSpawner.dartsCreatedOnDartboard > 0 && dartSpawner.running && dartMiniGameTimerRunning)
        {
            dartMiniGameTimeText.gameObject.SetActive(true);
            dartMiniGameTimeLeft -= Time.deltaTime;
            if (dartMiniGameTimeLeft < 0)
            {
                dartMiniGameTimerRunning = false;
            }
            int tiempoMin2 = Mathf.FloorToInt(dartMiniGameTimeLeft / 60);
            int tiempoSeg2 = Mathf.FloorToInt(dartMiniGameTimeLeft % 60);

            dartMiniGameTimeText.text = string.Format("{00:00}:{01:00}", tiempoMin2, tiempoSeg2);
        }

        if (!dartSpawner.running)
        {
            dartMiniGameTimeText.gameObject.SetActive(false);
            dartTimeText.gameObject.SetActive(false);
        }
    }
}
