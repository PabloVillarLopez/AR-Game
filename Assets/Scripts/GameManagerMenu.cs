using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public AudioClip pressSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(pressSound);
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        audioSource.PlayOneShot(pressSound);
        Application.Quit();
    }
}
