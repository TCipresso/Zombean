using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerTrig : MonoBehaviour
{
    public CashShower Cash;
    public Hazard Haz;
    public SkullBoss Skull;
    public Laserbeam Laser;
    public Build bob;

    private Dictionary<string, float> sectionEntryTimes = new Dictionary<string, float>();
    private const float THRESHOLD_TIME = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cash = GetComponent<CashShower>();
        Haz = GetComponent<Hazard>();
        Skull = GetComponent<SkullBoss>();
        Laser = GetComponent<Laserbeam>();
        bob = GetComponent<Build>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!sectionEntryTimes.ContainsKey(other.tag))
        {
            sectionEntryTimes.Add(other.tag, Time.time);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (sectionEntryTimes.ContainsKey(other.tag) && Time.time - sectionEntryTimes[other.tag] > THRESHOLD_TIME)
        {
            TriggerEventForTag(other.tag);
            sectionEntryTimes.Clear(); // Clear the dictionary after triggering an event.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (sectionEntryTimes.ContainsKey(other.tag))
        {
            sectionEntryTimes.Remove(other.tag);
        }
    }

    private void TriggerEventForTag(string tag)
    {
        switch (tag)
        {
            case "Build":
                Debug.Log("Build activated");
                bob.Construct();
                break;
            case "Skull":
                Debug.Log("Skull Activated");
                Skull.SpawnSkull();
                break;
            case "Money":
                Debug.Log("Money Activated");
                CashShower.Instance.Spawn();
                break;
            case "Star":
                Debug.Log("Star Activated");
                Laser.FireLasers();
                break;
            case "Ex":
                Debug.Log("Ex Activated");
                Haz.SpawnHazard();
                break;
            case "Question":
                Debug.Log("Question Activated");
                // Handle question logic here
                break;
        }
    }
}
