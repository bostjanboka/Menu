using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {

    // Use this for initialization
    int state = 0;
    int id;
    public Toggle key;
    public bool saveState = false;
	void Start () {
        key = GetComponent<Toggle>();
        id = key.GetInstanceID();
        if (PlayerPrefs.HasKey("bokaToggle" + id))
        {
            state = PlayerPrefs.GetInt("bokaToggle" + id);
        }
        else
        {
            PlayerPrefs.SetInt("bokaToggle" + id, bool2int(key.isOn));
        }
        if(state == 1)
        {
            key.isOn = true;
        }
        else
        {
            key.isOn = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onStateChanged()
    {
        if (saveState)
        {
            PlayerPrefs.SetInt("bokaToggle" + id, bool2int(key.isOn));
        }
    }

    int bool2int(bool boolean)
    {
        if (boolean)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    } 


}
