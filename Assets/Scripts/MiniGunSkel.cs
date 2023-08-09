using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunSkel : MonoBehaviour
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

    void Update()
    {
        OnFire();
    }

    void OnFire()
    {
        if (MenuLogic.isPaused) return;
        if (Input.GetMouseButton(0))
        {
            if (TimeBS <= 0f)
            {
                var bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, Quaternion.LookRotation(BulletSpawnPoint.up)); // BulletSpawnPoint.rotation
                bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.up * bulletSpeed;

                TimeBS = 1 / FireRate;
                Instantiate(MuzzleFlashPrefab, BulletSpawnPoint.position, Quaternion.LookRotation(BulletSpawnPoint.up));//Quaternion.identity
                aud.PlayOneShot(aud.clip);
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
