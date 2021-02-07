using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectScript : MonoBehaviour
{
    public int selectedWeapon;
    public int previousWeapon;


    void Start()
    {
        selectedWeapon = 0;
        previousWeapon = 0;
        selectWeapon();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedWeapon = 3;
        }


        if (previousWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }

    void selectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(selectedWeapon >= this.transform.childCount)
            {
                selectedWeapon = 0;
                Debug.Log(this.transform.childCount);
            }
            if(i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }

        previousWeapon = selectedWeapon;
    }
}
