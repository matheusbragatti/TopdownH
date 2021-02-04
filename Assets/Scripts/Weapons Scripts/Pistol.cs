using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage;
    public GameObject shotEffect;
    public GameObject muzzleFlash;
    public int muzzleFlashDuration = 2;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            Debug.Log("shoot");
        }
        
    }


    void shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, this.transform.up);
        if(hitInfo.collider != null)
        {
            if(hitInfo.transform.tag == "Enemy")
            {
                hitInfo.transform.GetComponent<EnemyScript>().takeDamage(this.damage);

            }
            StartCoroutine(muzzleFlashPlay());
            GameObject visualEffect = Instantiate(shotEffect, hitInfo.point, Quaternion.identity);
            Destroy(visualEffect, 2f);
        }
        else
        {

        }
    }

    IEnumerator muzzleFlashPlay()
    {
        muzzleFlash.SetActive(true);
        int duration = 0;

        while(duration <= muzzleFlashDuration)
        {
            duration++;
            yield return null;
        }
        muzzleFlash.SetActive(false);
    }
}
