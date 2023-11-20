using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectEvolutionsPau : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        sanPau.SetActive(true);
        evolution1.SetActive(false);
        evolution2.SetActive(false);
        evolution3.SetActive(false);
        evolution2Enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Evolution1()
    {
        if (!evolution2Enabled && !evolution3Enabled)
        {
            sanPau.SetActive(false);
            evolution1.SetActive(true);
            evolution2.SetActive(false);
            evolution3.SetActive(false);
            evolution1Enabled = true;

            evolution1bool = true;
            evolution2bool = false;
            evolution3bool = false;
        }

    }

    public void Evolution2()
    {
        if (!evolution3Enabled)
        {
            evolution1Enabled = false;
            sanPau.SetActive(false);
            evolution1.SetActive(false);
            evolution2.SetActive(true);
            evolution3.SetActive(false);
            evolution2Enabled = true;

            evolution1bool = false;
            evolution2bool = true;
            evolution3bool = false;
        }

    }

    public void Evolution3()
    {
        if (!evolution1Enabled)
        {
            evolution2Enabled = false;
            sanPau.SetActive(false);
            evolution1.SetActive(false);
            evolution2.SetActive(false);
            evolution3.SetActive(true);
            evolution3Enabled = true;

            evolution1bool = false;
            evolution2bool = false;
            evolution3bool = true;
        }

    }

    private void OnMouseDown()
    {
        if (PointsBoardManager.totalPoints > 0 && PointsBoardManager.totalPoints < 100)
        {
            Evolution1();
        }

        if (PointsBoardManager.totalPoints > 100 && PointsBoardManager.totalPoints < 200)
        {
            Evolution2();
        }

        if (dartSpawner.points > 150 && moleSpawner.points > 150)
        {
            Evolution3();
        }
    }

    //Para cambiar el input al nuevo sistema de inputs
    public void Touch(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (PointsBoardManager.totalPoints > 0 && PointsBoardManager.totalPoints < 100)
            {
                Evolution1();
            }

            if (PointsBoardManager.totalPoints > 100 && PointsBoardManager.totalPoints < 200)
            {
                Evolution2();
            }

            if (PointsBoardManager.totalPoints > 200 && PointsBoardManager.totalPoints < 500)
            {
                Evolution3();
            }
        }
    }
}
