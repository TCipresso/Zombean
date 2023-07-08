using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour
{


    public Transform BulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float TimeBS;
    public float FireRate;
    AudioSource aud;
    public GameObject MuzzleFlashPrefab;

    void Start()
    {
        TimeBS = 1 / FireRate;
        aud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        OnFire();
    }

    void OnFire()
    {
        if (Input.GetMouseButton(0))
        {
            if (TimeBS <= 0f)
            {
                var bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, Quaternion.LookRotation(BulletSpawnPoint.up)); // BulletSpawnPoint.rotation
                bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.up * bulletSpeed;
                
                //transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);

                TimeBS = 1 / FireRate;
                Instantiate(MuzzleFlashPrefab, BulletSpawnPoint.position, Quaternion.LookRotation(BulletSpawnPoint.up));//Quaternion.identity
                aud.Play();
                
            }
            else
            {
                TimeBS -= Time.deltaTime;
            }
        }
        else
        {
            TimeBS = 0f;
        }

    }


}
