using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    [SerializeField] private GameObject _bolt;
    [SerializeField] private int _damage = 2;
    Rigidbody bolt_Rigidbody;

    public void Fire()
    {
        GameObject boltObj = Instantiate(_bolt, _bolt.transform.position, _bolt.transform.rotation);
        boltObj.SetActive(true);
        bolt_Rigidbody = boltObj.GetComponent<Rigidbody>();
        bolt_Rigidbody.AddRelativeForce(0, 1, -40, ForceMode.Impulse);
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Player>() != null)
        {
            var player = other.GetComponent<PlayerCharacteristics>();
            player.Hurt(_damage);

            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<Wall>() != null)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponent<Ground>() != null)
        {
            Destroy(gameObject);
        }
    }


}

