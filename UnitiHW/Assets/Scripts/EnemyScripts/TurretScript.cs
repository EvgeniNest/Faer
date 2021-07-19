using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] private GameObject _crossBow;
    [SerializeField] private GameObject _bolt;
    [SerializeField] private int boltCount = 2;
    [SerializeField] private bool findPlayer;
    [SerializeField] private bool _rightEnd;
    [SerializeField] private GameObject Player;
    private bool isFire;

    float time = 0f;    //Таймер


    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
        }

        if (findPlayer is false)
        {
            if (_rightEnd is false)
            {
                _crossBow.transform.Rotate(Vector3.up * (15 * Time.deltaTime));

                if (_crossBow.transform.rotation.eulerAngles.y >= 90)
                {
                    _rightEnd = true;
                    return;
                }
            }
            else if (_rightEnd is true)
            {
                _crossBow.transform.Rotate(Vector3.down * (15 * Time.deltaTime));

                if (_crossBow.transform.rotation.eulerAngles.y <= 5)
                {
                    _rightEnd = false;
                    return;
                }
            }
        }

        else 
        {
            Vector3 targetDirection = _crossBow.transform.position - Player.transform.position ;
            Vector3 finalDirection = new Vector3(targetDirection.x,0,targetDirection.z);
            float singleStep = 2 * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, finalDirection, singleStep, 0.0f);
            _crossBow.transform.rotation = Quaternion.LookRotation(newDirection);

            if (isFire == false && time <=0)
            {
                if (boltCount > 0)
                {
                    time = 0.5f;
                    _bolt.GetComponent<BoltScript>().Fire();
                    boltCount -= 1;
                    isFire = true;
                }
                else if(boltCount <= 0)
                {
                    _crossBow.GetComponent<TurretScript>().enabled = false;
                }
            }
            else if(isFire == true && time <= 0)
            {
                time = 0.5f;
                isFire = false;
                return;
            }

        }
    }
    public void Find()
    {
        
            findPlayer = true;

    }
    public void Miss()
    {

        findPlayer = false;

    }

}
