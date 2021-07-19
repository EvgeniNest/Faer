using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeathGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            var player = other.GetComponent<PlayerCharacteristics>();
            player.Hurt(player.HPView());
        }
        else if(other.gameObject.GetComponent<Enemy>() != null)
        {
            var enemy = other.GetComponent<EnemyHealth>();
            enemy.Hurt(Convert.ToInt32(enemy.healthView()));
        }
    }
}
