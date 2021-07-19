using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private GameObject _HPUi;

    [SerializeField] private GameObject _enemyHealth;

    void Start()
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(_enemyHealth.GetComponent<EnemyHealth>().healthView());
    }

    public void addHPCount(int count)
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_HPUi.GetComponent<Text>().text) + count);
    }

    public void deleteHPCount(int count)
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_HPUi.GetComponent<Text>().text) - count);
    }
}