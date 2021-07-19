using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGroundS : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy;
    [SerializeField] private Transform _spawn1;
    [SerializeField] private Transform _spawn2;
    [SerializeField] private Transform _spawn3;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() !=null)
        {
            GameObject Enemy1 = Instantiate(_Enemy,(_spawn1.transform.position),(_spawn1.transform.rotation));
            Enemy1.SetActive(true);
            Enemy1 = Instantiate(_Enemy, (_spawn2.transform.position), (_spawn2.transform.rotation));
            Enemy1.SetActive(true);
            Enemy1 = Instantiate(_Enemy, (_spawn3.transform.position), (_spawn3.transform.rotation));
            Enemy1.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

}
