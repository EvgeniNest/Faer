using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;
    private bool isHurt;
    private GameObject _EnemyCollider;
    [SerializeField] private GameObject _Enemy;

    [SerializeField] private GameObject _enemyUI;

    void Start()
    {
        _EnemyCollider = (GameObject)this.gameObject;
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        isHurt = true;
        _enemyUI.GetComponent<EnemyUI>().deleteHPCount(damage);
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(_Enemy);
    }
    public float healthView()
    {
        return _health;
    }
}
