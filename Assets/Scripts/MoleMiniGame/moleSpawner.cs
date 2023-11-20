using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class moleSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] moles;
    private int randomMoleNumber;
    private int randomSpawnPointNumber;
    public static int molesCreatedAlive;
    public static int points;
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI pointsText;
    //public TextMeshProUGUI molesAliveText;

    public int numOfRounds;
    public Slider sliderNumOfRounds;
    public TextMeshProUGUI numOfRoundsText;

    public static bool moleGameStopped;
    public Button easyButton;
    public Button intermediateButton;
    public Button hardButton;
    public Button insaneButton;
    public Button startButton;
    public Button stopButton;
    public TextMeshProUGUI difficultyText;
    public static float moleWaitTime;
    public static bool moleMinigameRunning;

    public static float totalTimeOfGame;

    public enum Levels
    {
        EASY,
        INTERMEDIATE,
        HARD,
        INSANE
    }

    public Levels level;
    public GameObject explicativeMolePanel;

    private AudioSource audioSource;
    public AudioClip moleSound;
    public AudioClip buttonPressedSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //molesAliveText.text = string.Empty;
        statusText.text = "Not Running";

        moleMinigameRunning = false;
        moleGameStopped = false;
        level = Levels.INTERMEDIATE;
        moleWaitTime = 3f;
        difficultyText.text = "Difficulty: " + level.ToString();
        totalTimeOfGame = (int)moleWaitTime * numOfRounds;
        explicativeMolePanel.SetActive(true);
    }

    private void Update()
    {
        pointsText.text = "Points: " + points.ToString();
        //molesAliveText.text = "Moles Alive: " + molesCreatedAlive.ToString();
        numOfRounds = (int)sliderNumOfRounds.value;
        numOfRoundsText.text = "Number of Rounds: " + numOfRounds.ToString();

        if (moleMinigameRunning)
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
        }

        if (!moleMinigameRunning)
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
        }
    }

    public void RandomSpawn()
    {
        if (molesCreatedAlive < 1)
        {
            MoleTimerController.moleTimerRunning = true;
            MoleTimerController.moleSeg = moleWaitTime;
            MoleTimerController.moleTimeLeft = (MoleTimerController.moleMin * 60) + MoleTimerController.moleSeg;

            statusText.text = "Running";
            randomMoleNumber = Random.Range(0, moles.Length);
            randomSpawnPointNumber = Random.Range(0, spawnPoints.Length - 1);
            Debug.Log(randomMoleNumber);
            if (randomMoleNumber == 0)
            {
                Instantiate(moles[randomMoleNumber], spawnPoints[randomSpawnPointNumber].transform.position - new Vector3(0.5f, 1.5f, -0.2f), moles[randomMoleNumber].transform.rotation);
                audioSource.PlayOneShot(moleSound);
            }
            else if (randomMoleNumber == 1 || randomMoleNumber == 2)
            {
                audioSource.PlayOneShot(moleSound);
                Instantiate(moles[randomMoleNumber], spawnPoints[randomSpawnPointNumber].transform.position + new Vector3(0, 0.5f, 0), moles[randomMoleNumber].transform.rotation);
            }
            
            molesCreatedAlive++;
            
        }

    }

    public void StartMoleMinigame()
    {
        StartCoroutine("MoleMinigame");
    }

    public IEnumerator MoleMinigame()
    {
        explicativeMolePanel.SetActive(false);
        moleGameStopped = false;
        MoleTimerController.moleMiniGameTimerRunning = true;
        totalTimeOfGame = moleWaitTime * numOfRounds;
        Debug.Log(totalTimeOfGame);
        MoleTimerController.moleGameSeg = (int)totalTimeOfGame;
        MoleTimerController.moleMiniGameTimeLeft = (MoleTimerController.moleGameMin * 60) + MoleTimerController.moleGameSeg;

        for (int i = 0; i < numOfRounds; i++)
        {
            moleMinigameRunning = true;
            RandomSpawn();

            yield return new WaitForSeconds(moleWaitTime);
            MoleTimerController.moleTimerRunning = false;
        }
        statusText.text = "Not Running";
        moleMinigameRunning = false;
        MoleTimerController.moleMiniGameTimerRunning = false;
        explicativeMolePanel.SetActive(true);
    }

    public void EasyLevel()
    {
        if (!moleMinigameRunning)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.EASY;
            difficultyText.text = "Difficulty: Easy";
            moleWaitTime = 3f;
        }
        Debug.Log(level);
    }

    public void IntermediateLevel()
    {
        if (!moleMinigameRunning)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.INTERMEDIATE;
            difficultyText.text = "Difficulty: Intermediate";
            moleWaitTime = 1.5f;
        }
        Debug.Log(level);
    }

    public void HardLevel()
    {
        if (!moleMinigameRunning)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.HARD;
            difficultyText.text = "Difficulty: Hard";
            moleWaitTime = 0.6f;
        }
        Debug.Log(level);
    }

    public void InsaneLevel()
    {
        if (!moleMinigameRunning)
        {
            audioSource.PlayOneShot(buttonPressedSound);
            level = Levels.INSANE;
            difficultyText.text = "Difficulty: Insane";
            moleWaitTime = 0.3f;
        }
        Debug.Log(level);
    }

    public void StopMoleMiniGame()
    {
        audioSource.PlayOneShot(buttonPressedSound);
        StopAllCoroutines();
        moleMinigameRunning = false;
        moleGameStopped = true;
        statusText.text = "Not Running";
        MoleTimerController.moleTimerRunning = false;
        explicativeMolePanel.SetActive(true);
    }
}
