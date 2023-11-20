using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dartSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject dart;
    public static int dartsCreatedOnDartboard;
    public static int points;
    public TextMeshProUGUI statusText;
    public static bool running;
    public TextMeshProUGUI pointsText;
    //public TextMeshProUGUI dartsCreatedOnDartboardText;

    public int numOfRounds;
    public Slider sliderNumOfRounds;
    public TextMeshProUGUI numOfRoundsText;

    public static float waitTime;
    public TextMeshProUGUI difficultyText;

    public Button easyButton;
    public Button intermediateButton;
    public Button hardButton;
    public Button insaneButton;
    public Button startButton;
    public Button stopButton;
    public static bool gameStopped;

    public static float totalTimeOfGame;

    public GameObject targetPrediction;

    private AudioSource audioSource;
    public AudioClip buttonPressedSound;

    public enum Levels
    {
        EASY,
        INTERMEDIATE,
        HARD,
        INSANE
    }

    public Levels level;

    public GameObject explicativeDartPanel;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        statusText.text = "Not Running";
        running = false;
        gameStopped = false;
        level = Levels.INTERMEDIATE;
        waitTime = 5f;
        targetScript.speed = 3f;
        targetYScript.speed = 5f;
        difficultyText.text = "Difficulty: " + level.ToString();
        totalTimeOfGame = (int)waitTime * numOfRounds;
        explicativeDartPanel.SetActive(true);
    }

    private void Update()
    {
        pointsText.text = "Points: " + points.ToString();
        //dartsCreatedOnDartboardText.text = "Darts on Dartboard: " + dartsCreatedOnDartboard.ToString();
        numOfRounds = (int)sliderNumOfRounds.value;
        numOfRoundsText.text = "Number of Rounds: " + numOfRounds.ToString();

        if (running)
        {
            audioSource.Play();
            sliderNumOfRounds.gameObject.SetActive(false);
            numOfRoundsText.gameObject.SetActive(false);
            easyButton.gameObject.SetActive(false);
            intermediateButton.gameObject.SetActive(false);
            hardButton.gameObject.SetActive(false);
            insaneButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(true);
            targetPrediction.SetActive(true);
        }

        if (!running)
        {
            audioSource.Stop();
            sliderNumOfRounds.gameObject.SetActive(true);
            numOfRoundsText.gameObject.SetActive(true);
            easyButton.gameObject.SetActive(true);
            intermediateButton.gameObject.SetActive(true);
            hardButton.gameObject.SetActive(true);
            insaneButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            targetPrediction.SetActive(false);
        }

        
    }

    public void RandomSpawn()
    {
        if (dartsCreatedOnDartboard < 1)
        {
            DartTimeController.dartTimerRunning = true;
            DartTimeController.dartSeg = (int)waitTime;
            DartTimeController.dartTimeLeft = (DartTimeController.dartMin * 60) + DartTimeController.dartSeg;

            statusText.text = "Running";
            Instantiate(dart, spawnPoint.transform.position, dart.transform.rotation);
            dartsCreatedOnDartboard++;
        }

    }

    public void StartDartMinigame()
    {
        if (!moleSpawner.moleMinigameRunning)
        {
            StartCoroutine("DartMinigame");
        }
        
    }

    public IEnumerator DartMinigame()
    {
        explicativeDartPanel.SetActive(false);
        gameStopped = false;
        DartTimeController.dartMiniGameTimerRunning = true;
        totalTimeOfGame = waitTime * numOfRounds;
        DartTimeController.gameSeg = (int)totalTimeOfGame;
        DartTimeController.dartMiniGameTimeLeft = (DartTimeController.gameMin * 60) + DartTimeController.gameSeg;

        for (int i = 0; i < numOfRounds; i++)
        {
            running = true;
            RandomSpawn();

            
            yield return new WaitForSeconds(waitTime);
            DartTimeController.dartTimerRunning = false;
        }
        statusText.text = "Not Running";
        running = false;
        DartTimeController.dartMiniGameTimerRunning = false;
        explicativeDartPanel.SetActive(true);
    }

    public void EasyLevel()
    {
        if (!running)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.EASY;
            difficultyText.text = "Difficulty: Easy";
            waitTime = 7f;
            targetScript.speed = 2f;
            targetYScript.speed = 4f;
        }
        Debug.Log(level);
    }

    public void IntermediateLevel()
    {
        if (!running)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.INTERMEDIATE;
            difficultyText.text = "Difficulty: Intermediate";
            waitTime = 5f;
            targetScript.speed = 3f;
            targetYScript.speed = 5f;
        }
        Debug.Log(level);
    }

    public void HardLevel()
    {
        if (!running)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.HARD;
            difficultyText.text = "Difficulty: Hard";
            waitTime = 3f;
            targetScript.speed = 5f;
            targetYScript.speed = 7f;
        }
        Debug.Log(level);
    }

    public void InsaneLevel()
    {
        if (!running)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.INSANE;
            difficultyText.text = "Difficulty: Insane";
            waitTime = 1.5f;
            targetScript.speed = 7f;
            targetYScript.speed = 10f;
        }
        Debug.Log(level);
    }

    public void StopDartMiniGame()
    {
        audioSource.PlayOneShot(buttonPressedSound);
        StopAllCoroutines();
        running = false;
        gameStopped = true;
        DartTimeController.dartTimerRunning = false;
        statusText.text = "Not Running";
        explicativeDartPanel.SetActive(true);
    }
}
