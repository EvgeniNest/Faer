using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject _uiTest;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _uiTest.GetComponent<TestUIScript>().addCount(1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _uiTest.GetComponent<TestUIScript>().deleteCount(1);
        }
    }
}
