using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private GameObject Player;  //Объект игрока (объект персонажа)
    private int speed = 5; 
    private int speedRotation = 3;
    private AudioSource Audio;
    private float time = 0f;
    private Rigidbody Player_rigidbody;
    private Animator animator;
    public bool isMoving;
    private bool isAttack;

    [SerializeField] private GameObject InventoryObj;
    private Inventory _inventory;

    void Start()
    {
        Player = (GameObject)this.gameObject;
        Audio = GetComponent<AudioSource>();
        Player_rigidbody = Player.GetComponent<Rigidbody>();
        animator = Player.GetComponent<Animator>();
        _inventory = InventoryObj.GetComponent<Inventory>();
    }


    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
        }
        if (isAttack == false && time <=0)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    Player.transform.position += Player.transform.forward * (speed / 1.5f) * Time.deltaTime;
                    Player.transform.position -= Player.transform.right * (speed / 1.5f) * Time.deltaTime;
                    animator.Play("1H@Run01 - ForwardLeft");
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Player_rigidbody.AddRelativeForce(-150, 10, 150, ForceMode.Impulse);
                    }
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    Player.transform.position += Player.transform.forward * (speed / 1.5f) * Time.deltaTime;
                    Player.transform.position += Player.transform.right * (speed / 1.5f) * Time.deltaTime;
                    animator.Play("1H@Run01 - ForwardRight");
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Player_rigidbody.AddRelativeForce(150, 10, 150, ForceMode.Impulse);
                    }
                }
                else
                {
                    Player.transform.position += Player.transform.forward * speed * Time.deltaTime; // Персонаж перемещается
                    animator.Play("1H@Run01 - Forward");//Включается анимация передвижения
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Player_rigidbody.AddRelativeForce(0, 10, 200, ForceMode.Impulse);
                    }
                }
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    Player.transform.position -= Player.transform.forward * (speed / 1.5f) * Time.deltaTime;
                    Player.transform.position -= Player.transform.right * (speed / 1.5f) * Time.deltaTime;
                    animator.Play("1H@Run01 - BackwardLeft");
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Player_rigidbody.AddRelativeForce(-150, 10, -150, ForceMode.Impulse);
                    }
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    Player.transform.position -= Player.transform.forward * (speed / 1.5f) * Time.deltaTime;
                    Player.transform.position += Player.transform.right * (speed / 1.5f) * Time.deltaTime;
                    animator.Play("1H@Run01 - BackwardRight");
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Player_rigidbody.AddRelativeForce(150, 10, -150, ForceMode.Impulse);
                    }
                }

                else
                {
                    Player.transform.position -= Player.transform.forward * speed * Time.deltaTime;

                    animator.Play("1H@Run01 - Backward");
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Player_rigidbody.AddRelativeForce(0, 10, -200, ForceMode.Impulse);
                    }
                }

                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Player.transform.position -= Player.transform.right * speed * Time.deltaTime;

                animator.Play("1H@Run01 - Left");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player_rigidbody.AddRelativeForce(-200, 10, 0, ForceMode.Impulse);
                }
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Player.transform.position += Player.transform.right * speed * Time.deltaTime;

                animator.Play("1H@Run01 - Right");
                isMoving = true;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player_rigidbody.AddRelativeForce(200, 10, 0, ForceMode.Impulse);
                }
            }
            else
            {
                isMoving = false;
            }

        }

        if (isMoving == false && time <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && time <= 0)
            {
                animator.Play("1H-RH@Attack01"); //Включается анимация атаки 
                Audio.Play(); //Включается звук атаки
                
                isAttack = true;
                time = 1f;
            }

            else if (Input.GetKeyDown(KeyCode.G) && time <= 0) //Зарезервировано для анимации броска гранаты
            {
                
                isAttack = true;
                time = 0.65f;

            }
            else
            {
                isAttack = false;
            }
          
        }   

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            if (other.gameObject.GetComponent<GrenadeItem>() != null)
            {
                _inventory.addGrenade();
                Destroy(other.gameObject);
            }
            else if (other.gameObject.GetComponent<AidKitItem>() != null)
            {
                _inventory.addAidKit();
                Destroy(other.gameObject);
            }
        }
    }

}
  
