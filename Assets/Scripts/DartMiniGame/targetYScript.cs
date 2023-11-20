using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetYScript : MonoBehaviour
{
    private int Movy;
    private float limitUp, limitDown;
    public float distanceUp, distanceDown;
    public static float speed;
    //public AudioSource destroyAudio;
    //public GameObject floatingText;
    //public Vector3 floatingTextPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Para el movimiento lateral
        Movy = 1;
        limitDown = transform.position.y - distanceDown;
        limitUp = transform.position.y + distanceUp;

        targetSpawner.targetsYCreated++;

    }

    // Update is called once per frame
    void Update()
    {
        //Muevo de lado a otro de un punto A a un punto B
        if (dartSpawner.running)
        {
            //Movimiento lateral
            transform.Translate(new Vector3(0, Movy, 0) * speed * Time.deltaTime, Space.World);

            if (transform.position.y > limitUp)
            {
                //transform.eulerAngles = new Vector3(0, 0, 0);
                Movy = -1;
            }

            if (transform.position.y < limitDown)
            {
                //transform.rotation = Quaternion.Euler(0, 180, 0);
                //transform.eulerAngles = new Vector3(0, 180, 0);
                Movy = 1;
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

    private void OnDestroy()
    {
        targetSpawner.targetsYCreated--;
    }
}
