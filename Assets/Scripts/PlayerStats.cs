using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int PlayerHp;
    public bool TakenDamage = false;
    Renderer rend;

    public HealthBar healthbar;

    //private CameraShake Shake;
    public bool IsShake = false;
    public GameObject GameOverScreen;

    
    void OnEnable()
    {
        Physics.IgnoreLayerCollision(6, 7, false);
        Physics.IgnoreLayerCollision(6, 9, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        healthbar.SetMaxHealth(PlayerHp);
        rend.material.SetColor("_Color", new Vector4(0, 212, 245, 255));
        Physics.IgnoreLayerCollision(6, 9, true);
    }

    // Update is called once per frame
    void Update()
    {

        healthbar.SetHealth(PlayerHp);
        if (PlayerHp <= 0)
        {
            Destroy(gameObject);
            GameOverScreen.SetActive(true);
        }
        if (PlayerHp > 100)
        {
            PlayerHp = 100;
        }
    }

    public void TakeDamageP(int damage)
    {
        if (!TakenDamage)
        {
            TakenDamage = true;
            PlayerHp -= damage;
            StartCoroutine(ISheld());
            Debug.Log("SHIELD STARTED");
        }
    }

    public IEnumerator ISheld()
    {
        Physics.IgnoreLayerCollision(6, 7, true);

        rend.material.SetColor("_Color", new Vector4(255, 255, 0, 255));
        IsShake = true;
        //StartCoroutine(cameraShake.Shake(0.15f, 0.1f));
        yield return new WaitForSecondsRealtime(3f);
        IsShake = false;
        Physics.IgnoreLayerCollision(6, 7, false);

        rend.material.SetColor("_Color", new Vector4(0, 212, 245, 255));
        Debug.Log("SHIELD  DONE");
        TakenDamage = false;
    }
    public void PlayerHeal()
    {
        PlayerHp += 40;
        //make this a random number in a range later
    }

    public void PlayerHealMax()
    {
        PlayerHp += 100;
        //make this a random number ina range later
    }
    public void HealZone(int amount)
    {
        PlayerHp = Mathf.Min(PlayerHp + amount, 100); // Ensure player health doesn't exceed 100
    }
}
