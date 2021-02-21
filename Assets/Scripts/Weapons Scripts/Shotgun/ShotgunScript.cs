using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public int maxAmmo;
    [SerializeField]
    private int currentAmmo;
    public float reloadTime;
    public int pellets;
    public float shotSpread;
    public GameObject shotEffect;
    public Vector3 shotSpreadAngle;
    public GameObject muzzleFlash;
    private Vector3 muzzleFlashPosition;
    private bool canShoot;
    private bool isRealoading;
    public AudioClip[] sounds;
    private AudioSource thisAudioSource;



    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        canShoot = true;
        isRealoading = false;
    }

    private void Start()
    {
        muzzleFlashPosition = new Vector3(0.004f, 0.1f, 0f);
        canShoot = true;
        currentAmmo = maxAmmo;
        isRealoading = false;
        thisAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo && !isRealoading)
        {
            StartCoroutine(reload());
        }

        if (Input.GetButton("Fire1") && canShoot && !isRealoading)
        {
            if(currentAmmo <= 0)
            {
                //Magazine empty
                StartCoroutine(reload());
                Debug.Log("reload");
            }
            else
            {
                StartCoroutine(shotsPerSecond());
            }
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
        currentAmmo--;

    }

    IEnumerator shotsPerSecond()
    {
        canShoot = false;
        shoot();
        thisAudioSource.PlayOneShot(sounds[0]);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    IEnumerator reload()
    {
        isRealoading = true;
        thisAudioSource.PlayOneShot(sounds[1]);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isRealoading = false;

    }

}
