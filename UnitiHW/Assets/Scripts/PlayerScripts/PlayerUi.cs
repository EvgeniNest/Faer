using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private GameObject _HPUi;
    [SerializeField] private GameObject _MPUi;
    [SerializeField] private GameObject _grenadeUi;
    [SerializeField] private GameObject _aidKitUi;

    [SerializeField] private GameObject _inventory;
    [SerializeField] private GameObject _playerCharact;

    void Start()
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(_playerCharact.GetComponent<PlayerCharacteristics>().HPView());
        _MPUi.GetComponent<Text>().text = Convert.ToString(_playerCharact.GetComponent<PlayerCharacteristics>().MPView());
        _grenadeUi.GetComponent<Text>().text = Convert.ToString(_inventory.GetComponent<Inventory>().grenadeCountView());
        _aidKitUi.GetComponent<Text>().text = Convert.ToString(_inventory.GetComponent<Inventory>().aidKitCountView());
    }

    public void addHPCount(int count)
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_HPUi.GetComponent<Text>().text) + count);
    }

    public void deleteHPCount(int count)
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_HPUi.GetComponent<Text>().text) - count);
    }

    public void addMPCount(int count)
    {
        _MPUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_MPUi.GetComponent<Text>().text) + count);
    }

    public void deleteMPCount(int count)
    {
        _MPUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_MPUi.GetComponent<Text>().text) - count);
    }

    public void addGrenadeCount(int count)
    {
        _grenadeUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_grenadeUi.GetComponent<Text>().text) + count);
    }

    public void deleteGrenadeCount(int count)
    {
        _grenadeUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_grenadeUi.GetComponent<Text>().text) - count);
    }

    public void addAidKitCount(int count)
    {
        _aidKitUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_aidKitUi.GetComponent<Text>().text) + count);
    }

    public void deleteAidKitCount(int count)
    {
        _aidKitUi.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(_aidKitUi.GetComponent<Text>().text) - count);
    }
    public void maxHP(int count)
    {
        _HPUi.GetComponent<Text>().text = Convert.ToString(count);
    }
    public void maxMP(int count)
    {
        _MPUi.GetComponent<Text>().text = Convert.ToString(count);
    }
}
