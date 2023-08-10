using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{

    public Dropdown drop;
    public Toggle FSToggle;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string resName = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            drop.options.Add(new Dropdown.OptionData(resName));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                drop.value = i;
            }
        }
    }

    public void SetResolution()
    {
        Resolution selectedResolution = resolutions[drop.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, FSToggle.isOn);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
