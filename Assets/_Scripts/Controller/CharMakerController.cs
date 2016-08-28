using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharMakerController : MonoBehaviour
{
    private List<GameObject> m_Tabs;
    private int m_LastActiveTabID;
	// Use this for initialization
	void Start ()
    {
        m_Tabs = new List<GameObject>();
        m_LastActiveTabID = 1;

        for (int i = 1; i < 4; i++)
        {
           m_Tabs.Add(GameObject.Find("Canvas").transform.Find("Tab" + i).gameObject);
            if (i > 1)
            {
                GameObject.Find("Canvas").transform.Find("Tab" + i).gameObject.SetActive(false);
            }
            
        }
	}
	

    public void ChangeTab(int id)
    {
        if (m_LastActiveTabID != id)
        {
            //Deactivate Last Activated Tab  and change Btn color
            ColorBlock colors = GameObject.Find("PanelBtn" + m_LastActiveTabID).GetComponent<Button>().colors;
            colors.normalColor = Color.gray;
            GameObject.Find("PanelBtn" + m_LastActiveTabID).GetComponent<Button>().colors = colors;
            m_Tabs[m_LastActiveTabID - 1].SetActive(false);

            colors = GameObject.Find("PanelBtn" + id).GetComponent<Button>().colors;
            colors.normalColor = Color.white;
            GameObject.Find("PanelBtn" + id).GetComponent<Button>().colors = colors;
            m_Tabs[id - 1].SetActive(true);

            m_LastActiveTabID = id;
        }
        
    }

    public void UpdateCharImage()
    {
    }
}
