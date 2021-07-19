using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _ray;
    private Color color;
    private GameObject _rayCaster;
    private float time;

    void Start()
    {
        _rayCaster = (GameObject)this.gameObject;
       
    }
   
     void FixedUpdate()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                _enemy.GetComponent<WalkEnemy>().enabled = true;
                _enemy.GetComponent<EnemyScript>().enabled = false;
                _enemy.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
            RaycastHit hit;
        color = Color.red;
        var startPos = transform.position;
        var dir = _ray.transform.position - _rayCaster.transform.position;
        var rayCast = Physics.Raycast(startPos, dir, out hit, 10, _mask);
        
        if (rayCast)
        {
            if (hit.collider.gameObject.GetComponent<Player>() != null)
            {
                color = Color.green;
                _enemy.GetComponent<WalkEnemy>().enabled = false;
                _enemy.GetComponent<EnemyScript>().enabled = true;
                _enemy.GetComponent<NavMeshAgent>().enabled = false;
                time = 7f;
                
            }
        }
        Debug.DrawRay(startPos, dir, color);
    }

}
