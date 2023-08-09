using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public MapSpin MapSpin; //public MapSpin MapSpin;
    public float pointInc;
    public int pointInc2;
    public int pointIncNum2;
    public float growthFactor;
    public int PlayerHealStart;
    public int playerScore;
    public Text pointsText;
    public bool Circ = false;
    public GameObject BasicGun;
    public GameObject COD;
    public GameObject MiniGun;
    public GameObject Shotgun;
    public GameObject RocketLauncher;
    public PlayerStats Stats; //public PlayerStats Stats;
    private Coroutine _currentPowerUpCoroutine;
    

    // Start is called before the first frame update
    void start()
    {
        StartCoroutine(ResetBasicGun());
        Stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        MapSpin = GameObject.FindGameObjectWithTag("Map").GetComponent<MapSpin>();
        //growthFactor = 1.5f;
      
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    [ContextMenu("increase score")]
    public void AddPoints()
    {
        playerScore += 10;
        pointsText.text = playerScore.ToString();

        if (playerScore >= PlayerHealStart * pointInc) // set to 1000
        {
            Stats.PlayerHealMax();
            pointInc *= growthFactor; // Multiply by growthFactor 
            float RNGSpinTime = Random.Range(5f, 8f);
            MapSpin.StartSpinning(RNGSpinTime);
        }
    }

    public void StartCirc()
    {
        COD.SetActive(true);
        StartCoroutine(RingTimer());
    }

    public IEnumerator RingTimer()
    {
        yield return new WaitForSecondsRealtime(10f);
        COD.SetActive(false);
        Debug.Log("COD deactivated");

    }

    public void MiniStart()
    {
        if (_currentPowerUpCoroutine != null)
        {
            StopCoroutine(_currentPowerUpCoroutine);
        }
        RocketLauncher.SetActive(false);
        Shotgun.SetActive(false);
        BasicGun.SetActive(false);
        MiniGun.SetActive(true);
        _currentPowerUpCoroutine = StartCoroutine(MiniTimer());
    }

    public IEnumerator MiniTimer()
    {
        yield return new WaitForSecondsRealtime(10f);
        BasicGun.SetActive(true);
        MiniGun.SetActive(false);
        Shotgun.SetActive(false);
        RocketLauncher.SetActive(false);
        _currentPowerUpCoroutine = null;
        Debug.Log("Minigun deactivated");
    }

    public void ShottyStart()
    {
        if (_currentPowerUpCoroutine != null)
        {
            StopCoroutine(_currentPowerUpCoroutine);
        }
        MiniGun.SetActive(false);
        RocketLauncher.SetActive(false);
        BasicGun.SetActive(false);
        Shotgun.SetActive(true);
        _currentPowerUpCoroutine = StartCoroutine(ShottyTimer());
    }

    public IEnumerator ShottyTimer()
    {
        yield return new WaitForSecondsRealtime(10f);
        BasicGun.SetActive(true);
        Shotgun.SetActive(false);
        MiniGun.SetActive(false);
        RocketLauncher.SetActive(false);
        _currentPowerUpCoroutine = null;
        Debug.Log("Shotgun deactivated");
    }

    public void RocketStart()
    {
        if (_currentPowerUpCoroutine != null)
        {
            StopCoroutine(_currentPowerUpCoroutine);
        }
        BasicGun.SetActive(false);
        RocketLauncher.SetActive(true);
        Shotgun.SetActive(false);
        MiniGun.SetActive(false);
        _currentPowerUpCoroutine = StartCoroutine(RocketTimer());
    }

    public IEnumerator RocketTimer()
    {
        yield return new WaitForSecondsRealtime(10f);
        BasicGun.SetActive(true);
        RocketLauncher.SetActive(false);
        Shotgun.SetActive(false);
        MiniGun.SetActive(false);
        _currentPowerUpCoroutine = null;
        Debug.Log("Rocket deactivated");
    }

    public void FullBeanStart()
    {
        if (_currentPowerUpCoroutine != null)
        {
            StopCoroutine(_currentPowerUpCoroutine);
        }
        BasicGun.SetActive(false);
        RocketLauncher.SetActive(true);
        Shotgun.SetActive(true);
        MiniGun.SetActive(true);
        _currentPowerUpCoroutine = StartCoroutine(FullBeanTimer());
    }

    public IEnumerator FullBeanTimer()
    {
        yield return new WaitForSecondsRealtime(10f);
        BasicGun.SetActive(true);
        RocketLauncher.SetActive(false);
        Shotgun.SetActive(false);
        MiniGun.SetActive(false);
        _currentPowerUpCoroutine = null;
        Debug.Log("Full bean deactivated");
    }

    public IEnumerator ResetBasicGun()
    {
        BasicGun.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        BasicGun.SetActive(true);
    }

    


}
