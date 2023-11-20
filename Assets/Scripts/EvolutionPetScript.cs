using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class evolutionPetScript : MonoBehaviour
{
    public GameObject sanPau;
    public GameObject evolution1;
    public static bool evolution1bool = false;
    public GameObject evolution2;
    public static bool evolution2bool = false;
    public GameObject evolution3;
    public static bool evolution3bool = false;
    private bool evolution1Enabled;
    private bool evolution2Enabled;
    private bool evolution3Enabled;

    public Button evolution1Button;
    public Button evolution2Button;
    public Button evolution3Button;

    public GameObject stoneEvolution1;
    public GameObject stoneEvolution2;
    public GameObject stoneEvolution3;

    public GameObject adviceOfEvolution;

    //private AudioSource audioSource;
    //public AudioClip evolutionSound;

    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sanPau.SetActive(true);
        evolution1.SetActive(false);
        evolution2.SetActive(false);
        evolution3.SetActive(false);
        evolution2Enabled = false;

        evolution1Button.gameObject.SetActive(false);
        evolution2Button.gameObject.SetActive(false);
        evolution3Button.gameObject.SetActive(false);

        stoneEvolution1.SetActive(false);
        stoneEvolution2.SetActive(false);
        stoneEvolution3.SetActive(false);
        adviceOfEvolution.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PointsBoardManager.totalPoints > 19)
        {
            adviceOfEvolution.SetActive(true);
            evolution1Button.gameObject.SetActive(true);
            evolution2Button.gameObject.SetActive(false);
            evolution3Button.gameObject.SetActive(false);
        }

        if (PointsBoardManager.totalPoints > 29)
        {
            adviceOfEvolution.SetActive(true);
            evolution1Button.gameObject.SetActive(false);
            evolution2Button.gameObject.SetActive(true);
            evolution3Button.gameObject.SetActive(false);
        }

        if (dartSpawner.points > 29 && moleSpawner.points > 49)
        {
            adviceOfEvolution.SetActive(true);
            evolution1Button.gameObject.SetActive(false);
            evolution2Button.gameObject.SetActive(false);
            evolution3Button.gameObject.SetActive(true);
        }
    }

    public void Evolution1()
    {
        //audioSource.PlayOneShot(evolutionSound);
        adviceOfEvolution.SetActive(false);
        sanPau.SetActive(false);
        evolution1.SetActive(true);
        evolution2.SetActive(false);
        evolution3.SetActive(false);

        stoneEvolution1.SetActive(true);
        stoneEvolution2.SetActive(false);
        stoneEvolution3.SetActive(false);

        //evolution1Enabled = true;

        evolution1bool = true;
        evolution2bool = false;
        evolution3bool = false;
        evolution1Button.gameObject.SetActive(false);

    }

    public void Evolution2()
    {
        //audioSource.PlayOneShot(evolutionSound);
        adviceOfEvolution.SetActive(false);
        // evolution1Enabled = false;
        sanPau.SetActive(false);
        evolution1.SetActive(false);
        evolution2.SetActive(true);
        evolution3.SetActive(false);

        stoneEvolution1.SetActive(true);
        stoneEvolution2.SetActive(true);
        stoneEvolution3.SetActive(false);

        //evolution2Enabled = true;

        evolution1bool = false;
        evolution2bool = true;
        evolution3bool = false;
        evolution2Button.gameObject.SetActive(false);

    }

    public void Evolution3()
    {
        //audioSource.PlayOneShot(evolutionSound);
        adviceOfEvolution.SetActive(false);
        //evolution2Enabled = false;
        sanPau.SetActive(false);
        evolution1.SetActive(false);
        evolution2.SetActive(false);
        evolution3.SetActive(true);

        stoneEvolution1.SetActive(true);
        stoneEvolution2.SetActive(true);
        stoneEvolution3.SetActive(true);

        //evolution3Enabled = true;

        evolution1bool = false;
        evolution2bool = false;
        evolution3bool = true;
        evolution3Button.gameObject.SetActive(false);

    }
}
