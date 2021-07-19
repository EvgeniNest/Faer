using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private GameObject _ui;

    void Start()
    {
        _ui = (GameObject)this.gameObject;
    }


    public void addCount(int count)
    {
        _ui.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_ui.GetComponent<Text>().text) + count);
    }

    public void deleteCount(int count)
    {
        _ui.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_ui.GetComponent<Text>().text) - count);
    }
}
