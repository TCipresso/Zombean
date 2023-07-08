using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CODLogic : MonoBehaviour
{
    public int damage = 999;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombean"))
        {
            Enemy target = other.GetComponent<Enemy>();
            target.TakeDamage(damage);
        }
    }

    /*public void StartCOD(float duration)
    {
        StartCoroutine(ActivateCOD(duration));
    }

    private IEnumerator ActivateCOD(float duration)
    {
        gameObject.SetActive(true);
        Debug.Log("COD ACTIVATED");

        yield return new WaitForSeconds(duration);

        gameObject.SetActive(false);
        Debug.Log("COD DEACTIVATED");

        Destroy(gameObject); // Optionally destroy the COD object after deactivating it
    }*/
}
