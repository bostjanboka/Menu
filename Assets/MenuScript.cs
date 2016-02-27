using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour {

    // Use this for initialization

    public GameObject[] pages;
    public GameObject areYouSureYouWantToLeavePage;

    List<GameObject> stack;

    AudioListener audio;
    void Awake()
    {
        audio = GameObject.FindObjectOfType<AudioListener>();
        for(int i=0; i < pages.Length; i++)
        {
            pages[i] = Instantiate(pages[i]) as GameObject;
            pages[i].GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            pages[i].name = pages[i].name.Replace("(Clone)", "");
        }
        stack = new List<GameObject>();
        stack.Add(pages[0]);

        areYouSureYouWantToLeavePage = Instantiate(areYouSureYouWantToLeavePage) as GameObject;
        areYouSureYouWantToLeavePage.name = areYouSureYouWantToLeavePage.name.Replace("(Clone)", "");
    }
    void Start () {
        for(int i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        areYouSureYouWantToLeavePage.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onPageChanged(string prefabName)
    {
        if (prefabName.Equals("Exit"))
        {
            Application.Quit();
        }else if (prefabName.Equals("Cancel"))
        {
            areYouSureYouWantToLeavePage.SetActive(false);
        }else if (!stack[stack.Count - 1].name.Equals(prefabName))
        {
            stack[stack.Count - 1].SetActive(false);
            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i].name.Equals(prefabName))
                {
                    stack.Add(pages[i]);
                    pages[i].SetActive(true);
                    break;
                }
            }
        }
    }

    public void onBackPress()
    {
        if(stack.Count > 1)
        {
            stack[stack.Count - 1].SetActive(false);
            stack.RemoveAt(stack.Count - 1);
            stack[stack.Count - 1].SetActive(true);
        }
        else
        {
            areYouSureYouWantToLeavePage.SetActive(true);
        }
        
    }

    public void openScene(string name)
    {
        Application.LoadLevel(name);
    }

    public void muteSound()
    {
        if(audio != null)
            audio.enabled = false;
    }
}
