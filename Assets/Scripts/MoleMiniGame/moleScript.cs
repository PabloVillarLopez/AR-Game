using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class moleScript : MonoBehaviour
{
    public int molePoints;

    public static bool moleTouched = false;

    private void Start()
    {
        Destroy(gameObject, moleSpawner.moleWaitTime);
    }

    private void Update()
    {
        if (moleSpawner.moleGameStopped)
        {
            Destroy(gameObject);
        }

        if (moleSpawner.moleMinigameRunning && moleTouched)
        {
            moleSpawner.molesCreatedAlive--;
            moleSpawner.points += molePoints;
            StartCoroutine("Wait");
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        moleSpawner.molesCreatedAlive--;
        moleSpawner.points += molePoints;
        StartCoroutine("Wait");
        Destroy(gameObject);
    }



    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private void OnDestroy()
    {
        if (moleSpawner.molesCreatedAlive > 0)
        {
            moleSpawner.molesCreatedAlive--;
        }

        moleTouched = false;
    }
}
