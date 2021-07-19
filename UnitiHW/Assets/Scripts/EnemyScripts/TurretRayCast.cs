using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRayCast : MonoBehaviour
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
                _enemy.GetComponent<TurretScript>().Miss();
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
                
                _enemy.GetComponent<TurretScript>().Find();
                time = 7f;

            }
        }
        Debug.DrawRay(startPos, dir, color);
    }

}
