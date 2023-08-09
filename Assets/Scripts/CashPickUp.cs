using UnityEngine;

public class CashPickUp : MonoBehaviour
{
    public LogicScript Cash;
    public AudioClip pickUpSound;
    private AudioSource audioSource;

    void Start()
    {
        Cash = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, 8.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cash.AddPoints();

            PlaySoundAndDestroy();
        }
    }

    void PlaySoundAndDestroy()
    {
        if (audioSource && pickUpSound)
        {
            audioSource.PlayOneShot(pickUpSound);
        }

        
        Collider collider = GetComponent<Collider>();
        if (collider) collider.enabled = false;

      
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer) renderer.enabled = false;

        
        Destroy(gameObject, pickUpSound.length);
    }
}
