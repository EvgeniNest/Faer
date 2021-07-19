using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
   
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject Player;

    [SerializeField] private GameObject LAttackCollider; //Collider меча
    [SerializeField] private GameObject RAttackCollider; //Collider меча
    private GameObject _Enemy;
    private Animator animator;
    private AudioSource audio;
    [SerializeField] private AudioSource _attackAudio;
    [SerializeField] private AudioSource _idleAudio;
    private bool isAttack;
    private bool isMoving;
    float time = 0f;    //Таймер
    float audioTime= 0f;
   
    void Start()
    {
        _Enemy=(GameObject)this.gameObject;
        animator = _Enemy.GetComponent<Animator>();
        audio = _Enemy.GetComponent<AudioSource>();
        
    }
    void Update()
    {
        #region Timers
        if (time > 0f)
        {
            time -= Time.deltaTime;
        }
        if (audioTime > 0f)
        {
            audioTime -= Time.deltaTime;
        }
        #endregion

        if (isMoving is true && audioTime <= 0f)
        {
            StartCoroutine(MoveAudio());
        }
        if (isAttack is true && audioTime <= 0f)
        {
            Attack();
        }
        if (Vector3.Distance(Player.transform.position, _Enemy.transform.position) > 1.1)
        {
            if(time <= 0f)
            {
                _Enemy.transform.position = Vector3.MoveTowards(_Enemy.transform.position, Player.transform.position, _speed * Time.deltaTime);
                var horizontal = Player.transform.position.y;
                // Определить, в каком направлении вращаться
                Vector3 targetDirection = Player.transform.position - _Enemy.transform.position;

                float singleStep = _speed * Time.deltaTime * 2;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

                _Enemy.transform.rotation = Quaternion.LookRotation(newDirection);
                isMoving = true;
                isAttack = false;

                animator.Play("Z_Walk1_InPlace");//Включается анимация передвижения
            }
        }
        else if(Vector3.Distance(Player.transform.position,_Enemy.transform.position) < 1.1 )
        {
            if(isAttack is false)
            {
                time = 0.8f;
                isAttack = true;
                isMoving = false;
                animator.Play("Z_Attack");
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            if (RAttackCollider.GetComponent<BoxCollider>().enabled is true)
            {
                RAttackCollider.GetComponent<BoxCollider>().enabled = false;
                LAttackCollider.GetComponent<BoxCollider>().enabled = true;
                var player = other.GetComponent<PlayerCharacteristics>();
                player.Hurt(_damage);

            }
            else if(LAttackCollider.GetComponent<BoxCollider>().enabled is true)
            {
                LAttackCollider.GetComponent<BoxCollider>().enabled = false;
                RAttackCollider.GetComponent<BoxCollider>().enabled = true;
                var player = other.GetComponent<PlayerCharacteristics>();
                player.Hurt(_damage);
            }
        }
    }
    
    private void Attack()
    {
        audioTime = 1.5f;
        
        _attackAudio.Play();

    }
    private IEnumerator MoveAudio()
    {
        audioTime = 3f;
        _idleAudio.Play();
        yield return new WaitForSeconds(.3f);

    }

}