using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private GameObject _grenade;
    [SerializeField] private GameObject _grenadePos;
    [SerializeField] private GameObject _particle;
    [SerializeField] private GameObject _light;
    [SerializeField] private int _damage = 3;
    private Rigidbody grenade_Rigidbody;
    private float time = 0f;    //Таймер

    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Destroy(gameObject);
            }
        }
       
    }


    public  void ThrowGrenade()
    {
        GameObject grenadeObj = Instantiate(_grenade,(_grenadePos.transform.position), Camera.main.transform.rotation);
        grenadeObj.SetActive(true);
        grenade_Rigidbody = grenadeObj.GetComponent<Rigidbody>();
        grenade_Rigidbody.AddRelativeForce(0, 6, 7, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            var enemy = other.GetComponent<EnemyHealth>();
            enemy.Hurt(_damage);
            time = 0.2f;
            _particle.SetActive(true);
            _light.SetActive(true);
        }
    }
}
