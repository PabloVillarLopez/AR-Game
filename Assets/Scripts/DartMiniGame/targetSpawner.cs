using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetSpawner : MonoBehaviour
{
    public GameObject targetSpawnPointX1;
    public GameObject targetSpawnPointX2;
    public GameObject targetSpawnPointY1;
    public GameObject targetSpawnPointY2;
    public GameObject targetX1;
    public GameObject targetX2;
    public GameObject targetY1;
    public GameObject targetY2;
    public static int targetsXCreated;
    public static int targetsYCreated;
    private int randomNumberX;
    private int randomNumberY;

    // Update is called once per frame
    void Update()
    {
        if (targetsXCreated < 2)
        {
            randomNumberX = Random.Range(0, 11);
            if (randomNumberX == 0)
            {
                Instantiate(targetX1, targetSpawnPointX1.transform.position + new Vector3(0, 0, 0f), targetX1.transform.rotation);
            }
            else if (randomNumberX > 0)
            {
                Instantiate(targetX2, targetSpawnPointX2.transform.position - new Vector3(0, 0, 0f), targetX2.transform.rotation);
            }

        }

        if (targetsYCreated < 2)
        {
            randomNumberY = Random.Range(0, 11);
            if (randomNumberY == 0)
            {
                Instantiate(targetY1, targetSpawnPointY1.transform.position + new Vector3(0, -4f, 0), targetY1.transform.rotation);
            }
            else if (randomNumberY > 0)
            {
                Instantiate(targetY2, targetSpawnPointY2.transform.position - new Vector3(0, 6f, 0), targetY2.transform.rotation);
            }


        }
    }
}
