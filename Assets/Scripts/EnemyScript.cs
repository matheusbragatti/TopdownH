using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 50f;
    

    public void takeDamage(float damage)
    {
        Debug.Log(damage);
        health -= damage;
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

}
