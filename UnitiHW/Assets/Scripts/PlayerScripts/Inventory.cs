using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _grenadeCount = 0;  //Значение количества имеющихся гранат
    [SerializeField] private int _aidKitCount = 0;   //Значение количества имеющихся аптечек

    [SerializeField] private GameObject grenadeModel;
    [SerializeField] private GameObject aidKitModel;
    [SerializeField] private GameObject _playerUI;

    private PlayerUi _ui;

    [SerializeField] private int _gold = 0;

    void Start()
    {
        _ui = _playerUI.GetComponent<PlayerUi>();
    }

    void Update()
    {
        if (_grenadeCount == 0)
        {
            grenadeModel.SetActive(false);
        }
        else
        {
            grenadeModel.SetActive(true);
        }
        if (_aidKitCount == 0)
        {
            aidKitModel.SetActive(false);
        }
        else
        {
            aidKitModel.SetActive(true);
        }

    }

    public void addGrenade()
    {
        _grenadeCount += 1;
        _ui.addGrenadeCount(1);
    }

    public void addAidKit()
    {
        _aidKitCount += 1;
        _ui.addAidKitCount(1);
    }
    public void deleteGrenade()
    {
        _grenadeCount -= 1;
        _ui.deleteGrenadeCount(1);
    }

    public void deleteAidKit()
    {
        _aidKitCount -= 1;
        _ui.deleteAidKitCount(1);
    }
    public int grenadeCountView()
    {
        return _grenadeCount ;
    }
    public int aidKitCountView()
    {
        return _aidKitCount;
    }
}

