using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WalkEnemy : MonoBehaviour
{
    private GameObject _Enemy;
    private Animator animator;
    private bool Raycast;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private AudioSource _idleAudio;
    float audioTime = 0f;
    private int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        _Enemy = (GameObject)this.gameObject;
        animator = _Enemy.GetComponent<Animator>();
    }

    void Update()
    {
        if (audioTime > 0f)
        {
            audioTime -= Time.deltaTime;
        }
        if(audioTime <= 0f)
        {
            StartCoroutine(MoveAudio());
        }
        animator.Play("Z_Walk1_InPlace");
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
    private IEnumerator MoveAudio()
    {
        audioTime = 3f;
        _idleAudio.Play();
        yield return new WaitForSeconds(.3f);

    }
}
