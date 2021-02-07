using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public int pellets;
    public float shotSpread;
    public GameObject shotEffect;
    public Vector3 shotSpreadAngle;
    public GameObject muzzleFlash;
    private Vector3 muzzleFlashPosition;
    private bool canShoot;


    private void Start()
    {
        muzzleFlashPosition = new Vector3(0.004f, 0.1f, 0f);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(shotsPerSecond());
            Debug.Log("click");
        }

    }


    void shoot()
    {
        for(int i = 0; i < pellets; i++)
        {
            Vector3 shotSpreadPellet = Random.Range(-shotSpread, shotSpread) * this.transform.right;

            RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, shotSpreadPellet + this.transform.up);
            if (hitInfo.collider != null)
            {
                if (hitInfo.transform.tag == "Enemy")
                {
                    hitInfo.transform.GetComponent<EnemyScript>().takeDamage(this.damage);

                }
                GameObject visualEffect = Instantiate(shotEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(visualEffect, 2f);

            }
            else
            {

            }
        }


        Instantiate(muzzleFlash, transform.position, transform.parent.gameObject.transform.rotation, this.transform);

    }

    IEnumerator shotsPerSecond()
    {
        canShoot = false;
        shoot();
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnEnable()
    {
        canShoot = true;
    }
}
