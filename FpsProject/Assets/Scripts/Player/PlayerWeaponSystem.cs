using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    public Weapon mainWeapon;
    public Weapon secondaryWeapon;

    public Weapon inUseWeapon;
    public Vector3 targetDir;

    private void Awake()
    {
        Replacement(1);
    }

    private void Update()
    {
        inUseWeapon.GetComponent<Weapon>().time += Time.deltaTime;
    }

    public void Replacement(int num)
    {
        if (inUseWeapon != null)
        {
            inUseWeapon.gameObject.SetActive(false);
        }
        if (num == 1)
        {
            inUseWeapon = mainWeapon;
        }
        else
        {
            inUseWeapon = secondaryWeapon;
        }
        inUseWeapon.transform.localPosition = inUseWeapon.GetComponent<Weapon>().myPoint;
        inUseWeapon.gameObject.SetActive(true);
    }

    public void Trigger(bool value)
    {
        inUseWeapon.GetComponent<Weapon>().Trigger(value);
    }
}
