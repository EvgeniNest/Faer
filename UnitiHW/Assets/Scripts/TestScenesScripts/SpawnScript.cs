using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour

{
    [SerializeField] private GameObject _originalObj;
    [SerializeField] private int copyCount = 0;
    private GameObject copyObj;
   
    void Update()
    {
        if (copyCount < 10000)
        {
            copyObj = Instantiate(_originalObj);

            copyCount += 1;
        }
        
        //

    }
}
