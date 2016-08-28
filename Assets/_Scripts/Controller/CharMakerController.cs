using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharMakerController : MonoBehaviour
{
    private List<GameObject>    m_Tabs;             //character making tabs
    private int                 m_LastActiveTabID;  //remember last active tab opened

	// Use this for initialization
	void Start ()
    {
        m_Tabs              = new List<GameObject>();
        m_LastActiveTabID   = 1;

        //add panels on scene to the collection and set them deactive (first tab is always active on start)
        for (int i = 1; i < 4; i++)
        {
           m_Tabs.Add(GameObject.Find("Canvas").transform.Find("Tab" + i).gameObject);
            if (i > 1)
            {
                GameObject.Find("Canvas").transform.Find("Tab" + i).gameObject.SetActive(false);
            }
            
        }
	}
	
    //change tab
    public void ChangeTab(int _ID)
    {
        if (m_LastActiveTabID != _ID)
        {
            //Deactivate Last Activated Tab  and change Btn color
            ColorBlock colors = GameObject.Find("PanelBtn" + m_LastActiveTabID).GetComponent<Button>().colors;
            colors.normalColor = Color.gray;
            GameObject.Find("PanelBtn" + m_LastActiveTabID).GetComponent<Button>().colors = colors;
            m_Tabs[m_LastActiveTabID - 1].SetActive(false);

            colors = GameObject.Find("PanelBtn" + _ID).GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            GameObject.Find("PanelBtn" + _ID).GetComponent<Button>().colors = colors;
            m_Tabs[_ID - 1].SetActive(true);

            m_LastActiveTabID = _ID;
        }
        
    }

    //TODO: Change char picture when changing tab configuration
    //TODO: Add character pictures for changes
    public void UpdateCharImage()
    {
    }
}
