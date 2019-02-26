using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSourceBehivior : MonoBehaviour
{
    public float velocity;
    public Transform bulletsHolder;
    public GameObject bulletPrefab;
    public Transform barrel;
    public float fireRate; 
    public float nextfire; 

    public void Fire()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, barrel.position, Quaternion.identity, bulletsHolder);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * velocity; 
        }
    }
}
