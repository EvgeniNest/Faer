using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int _maxHP = 10;
    [SerializeField] private int _healthPoint = 10;

    [SerializeField] private int _maxMP = 5;
    [SerializeField] private int _manaPoint = 5;
    [SerializeField] private GameObject _playerUI;

    [SerializeField] private GameObject _deathUI;
    private PlayerUi _ui;


    public bool _check = false;

    void Start()
    {
        _ui = _playerUI.GetComponent<PlayerUi>();
    }

    void Update()
    {
        

        //Взаимодействие с рычагами
        if (Input.GetKeyDown(KeyCode.E))
        {
            _check = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            _check = false;
        }

    }
    public void Heal(int heal)
    {
        _healthPoint += heal;
        _ui.addHPCount(heal);
        if (_maxHP < _healthPoint)
        {
            _healthPoint = _maxHP;
            _ui.maxHP(_maxHP);
        }

    }
    public void Hurt(int damage)
    {
        _healthPoint -= damage;
        _ui.deleteHPCount(damage);
        if (_healthPoint <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        _deathUI.SetActive(true);
        Destroy(Player);
    }

    public int HPView() //Возвращает private значение
    {
        return _healthPoint;
    }

    public int MPView()//Возвращает private значение
    {
        return _manaPoint;
    }

}

