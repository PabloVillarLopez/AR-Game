using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{

    //Para cambiar el input al nuevo sistema de inputs
    public void Touch(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            float value = callbackContext.ReadValue<float>();
            Debug.Log(value);
            //dartSpawner.running = true;

            if (dartSpawner.running)
            {
                dartScript.dartTouched = true;
               
            }


            if (moleSpawner.moleMinigameRunning)
            {
                moleScript.moleTouched = true;
            }
        }
    }

    /*public IEnumerator WaitAndFalseDart()
    {
        yield return new WaitForSeconds(0.1f);
        
    }

    public IEnumerator WaitAndFalseMole()
    {
        yield return new WaitForSeconds(0.1f);
    }*/
}
