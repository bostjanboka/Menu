using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    // Use this for initialization
    public GameObject MainControl;
    Button myButton;
    public string onClickGo;
    void Awake()
    {
        MainControl = GameObject.Find("MainControl");
    }
	void Start () {
        myButton = GetComponent<Button>();
        if(onClickGo != null && onClickGo.Length > 0)
            myButton.onClick.AddListener(delegate { MainControl.GetComponent<MenuScript>().onPageChanged(onClickGo); });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
