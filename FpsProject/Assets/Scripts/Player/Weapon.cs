using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerWeaponSystem mySystem;
    public GameObject bulletPrefeb;
    public Queue<GameObject> readyBullets;
    public List<GameObject> inUseBullets;

    //무기가 위치할 곳
    public Vector3 myPoint;
    public Vector3 muzzlePoint;

    public enum WeaponType
    {
        SniperRifle,
        AutomaticRifle,
        Shotgun,
        Pistol
    }
    public WeaponType weaponType;
    public float bulletSpeed;
    public float delay;
    public float time;
    bool triggerOn;

    private void Awake()
    {
        MakeBulletPull();
    }

    void MakeBulletPull()
    {
        readyBullets = new Queue<GameObject>();
        inUseBullets = new List<GameObject>();

        for (int i = 0; i < 50; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefeb);
            newBullet.GetComponent<Bullet>().myGun = this;
            readyBullets.Enqueue(newBullet);
        }
    }

    public virtual void Trigger(bool value)
    {
        triggerOn = value;
    }

    public void Fire(Vector3 normalDir)
    {
        if (readyBullets.Count == 0)
        {
            return;
        }

        GameObject fireBullet = readyBullets.Dequeue();
        inUseBullets.Add(fireBullet);

        fireBullet.transform.position = muzzlePoint;
        fireBullet.transform.rotation = transform.rotation;
        fireBullet.SetActive(true);

        fireBullet.GetComponent<Bullet>().Launch(normalDir);
    }
}
