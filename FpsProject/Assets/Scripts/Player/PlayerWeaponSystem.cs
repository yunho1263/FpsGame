using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    public GameObject mainWeapon;
    public GameObject secondaryWeapon;

    public GameObject inUseWeapon;

    private void Awake()
    {
        Replacement(1);
    }

    public void Replacement(int num)
    {
        if (inUseWeapon != null)
        {
            inUseWeapon.SetActive(false);
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
        inUseWeapon.SetActive(true);
    }

    public void Trigger(Vector3 normalDir)
    {
        inUseWeapon.GetComponent<Weapon>().Fire(normalDir);
    }
}
