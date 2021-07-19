using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    private GameObject Obj;

    void Start()
    {
        Obj = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Obj.transform.Rotate(Vector3.up * (200 * Time.deltaTime));

    }
}
