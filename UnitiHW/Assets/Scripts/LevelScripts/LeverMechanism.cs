using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMechanism : MonoBehaviour
{
    [SerializeField] private GameObject _openDoor;
    Collider d_collider;
    void Start()
    {
        d_collider = _openDoor.GetComponent<BoxCollider>();
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerCharacteristics>()._check is true)
            {
                d_collider.isTrigger = true;
            }
        }
    }
}
