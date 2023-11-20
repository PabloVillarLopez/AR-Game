using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class targetScript : MonoBehaviour
{
    private int Movz;
    private float limitder, limitizq;
    public float distanciader, distanciaizq;
    public static float speed;
    //public AudioSource destroyAudio;
    //public GameObject floatingText;
    //public Vector3 floatingTextPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Para el movimiento lateral
        Movz = 1;
        limitizq = transform.position.z - distanciaizq;
        limitder = transform.position.z + distanciader;

        targetSpawner.targetsXCreated++;

    }

    // Update is called once per frame
    void Update()
    {
        //Muevo de lado a otro de un punto A a un punto B
        if (dartSpawner.running)
        {
            //Movimiento lateral
            transform.Translate(new Vector3(0, 0, Movz) * speed * Time.deltaTime, Space.World);

            if (transform.position.z > limitder)
            {
                //transform.eulerAngles = new Vector3(0, 0, 0);
                Movz = -1;
            }

            if (transform.position.z < limitizq)
            {
                //transform.rotation = Quaternion.Euler(0, 180, 0);
                //transform.eulerAngles = new Vector3(0, 180, 0);
                Movz = 1;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dart"))
        {
            //floatingTextPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            //GameObject textPrefab = Instantiate(floatingText, floatingTextPosition, Quaternion.identity);
            //textPrefab.GetComponentInChildren<TextMeshProUGUI>().text = dartSpawner.points.ToString();
            //destroyAudio.Play();
            //Destroy(this.gameObject, 0.15f);
        }
    }

    private void OnDisable()
    {
        targetSpawner.targetsXCreated--;
    }
}
