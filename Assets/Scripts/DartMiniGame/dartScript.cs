using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class dartScript : MonoBehaviour
{
    private Rigidbody dartRigy;
    public static bool launched = false;
    public int force;
    public int forceUp;
    public Vector3 forceDirection;
    public Vector3 forceDirectionUp;

    private bool prepareToLaunchUp;

    public static bool stickToDartBoard = false;

    public static bool dartTouched = false;

    private AudioSource audioSource;
    public AudioClip shotDartSound;
    public AudioClip dartImpactSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        dartRigy = GetComponent<Rigidbody>();
        Destroy(gameObject, dartSpawner.waitTime);
    }

    void Update()
    {

        if (dartSpawner.gameStopped)
        {
            Destroy(gameObject);
        }

        if (dartTouched && !launched && dartSpawner.running)
        {
            prepareToLaunchUp = true;
            audioSource.PlayOneShot(shotDartSound);
        }
    }

    

    private void FixedUpdate()
    {
        if (prepareToLaunchUp)
        {
            LaunchUp();
        }
    }

    public void LaunchUp()
    {
        dartRigy.AddForce(forceDirection * force, ForceMode.Impulse);
        dartRigy.AddForce(forceDirectionUp * forceUp, ForceMode.Impulse);
        launched = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dartboard"))
        {
            audioSource.PlayOneShot(dartImpactSound);
            stickToDartBoard = true;
            dartRigy.useGravity = false;
            dartRigy.velocity = Vector3.zero;
            dartRigy.constraints = RigidbodyConstraints.FreezePosition;
            //dartRigy.freezeRotation = true;
            Destroy(gameObject, 2f);
        }

        if (other.gameObject.CompareTag("Green"))
        {
            
            dartRigy.useGravity = false;
            dartRigy.velocity = Vector3.zero;
            if (!stickToDartBoard)
            {
                audioSource.PlayOneShot(dartImpactSound);
                dartSpawner.points += 2; ;
                Destroy(other.gameObject, 0.15f);
                Destroy(gameObject, 2f);
            }

        }

        if (other.gameObject.CompareTag("Red"))
        {
            
            dartRigy.useGravity = false;
            dartRigy.velocity = Vector3.zero;
            if (!stickToDartBoard)
            {
                audioSource.PlayOneShot(dartImpactSound);
                dartSpawner.points--;
                Destroy(other.gameObject, 0.15f);
                Destroy(gameObject, 2f);
            }

        }
    }

    private void OnDisable()
    {
        launched = false;
        stickToDartBoard = false;
        dartSpawner.dartsCreatedOnDartboard--;
        dartTouched = false;
    }
}
