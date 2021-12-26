using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Weapon myGun;

    Rigidbody myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 normalDir)
    {
        myBody.AddForce(normalDir * myGun.bulletSpeed);
    }

    public void PutInBack()
    {
        myBody.velocity = Vector3.zero;
        gameObject.SetActive(false);

        myGun.readyBullets.Enqueue(gameObject);
        myGun.inUseBullets.Remove(gameObject);
    }
}