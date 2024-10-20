using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] private GameObject point;

    private GameObject pickedObject = null; // para saber si tenemos un objeto o no en la mano 
    
    void Update()
    {
        if (pickedObject != null) 
        {

            if (Input.GetKey("r"))
            {
                
                pickedObject.GetComponent<Rigidbody>().useGravity = true;

                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                pickedObject.gameObject.transform.SetParent(null);

                RewardBehaviour objectReward = pickedObject.GetComponent<RewardBehaviour>();
                objectReward.IsRotating = true;

                pickedObject = null;
            }
        }

        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Premio"))  // comparamos el tag del objecto
        {
            if (Input.GetKey("e") && pickedObject ==null)  //al apretar la tecla "E" podemos agarrar el objeto mientras que no tengamos nada en la mano 
             {
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Rigidbody>().isKinematic = true;

                

                other.transform.position = point.transform.position;

                other.gameObject.transform.SetParent(point.gameObject.transform);

                pickedObject = other.gameObject;

                RewardBehaviour objectReward = pickedObject.GetComponent<RewardBehaviour>();
                objectReward.IsRotating = false;
            
            }
        }
    }
}
