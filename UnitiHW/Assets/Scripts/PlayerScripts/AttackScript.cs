using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
   

    [SerializeField] private int _damage = 1;  
    [SerializeField] private int _heal = 2;
    [SerializeField] private GameObject _sword;
    [SerializeField] private GameObject InventoryObj;
    [SerializeField] private GameObject CharacteristicsObj;
    [SerializeField] private GameObject grenadeThrow;   //Граната для броска
    private PlayerCharacteristics _playerCharact;
    private Inventory _inventory;
    [SerializeField]  private GameObject Player;
    private Collider AttackCollider;    //Collider меча


    private float time = 0f;    //Таймер

    void Start()
    {
        _playerCharact = CharacteristicsObj.GetComponent<PlayerCharacteristics>();
        _inventory = InventoryObj.GetComponent<Inventory>();
        AttackCollider = _sword.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            if (time <= 0f)
            {
                AttackCollider.enabled = false;
            }
        }
       
        if(Player.GetComponent<MoveScript>().isMoving == false)
        {
            //Атака мечом
            if (Input.GetKeyDown(KeyCode.Mouse0) && time <= 0)
            {
                AttackCollider.enabled = true;
                time = 1;
            }
            //Бросок гранаты

            if (Input.GetKeyDown(KeyCode.G) && time <= 0)
            {
                if (_inventory.grenadeCountView() > 0)
                {
                    grenadeThrow.GetComponent<Grenade>().ThrowGrenade();
                    _inventory.deleteGrenade();

                    time = 0.65f;
                }
            }

            //Лечение
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (_inventory.aidKitCountView() > 0)
                {
                    _playerCharact.Heal(_heal);
                    _inventory.deleteAidKit();
                }
            }

            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            var enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.Hurt(_damage);
            }
        }
        if (other.gameObject.GetComponent<BreakDoor>() != null)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Enemy>() == null)
        {
            AttackCollider.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
