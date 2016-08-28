using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BreederPanelModel
{
    private GameObject m_MainOverlay;
    private List<GameObject>  m_Overlays;

    private GameObject m_OpenOverlay;
	// Use this for initialization
	public void Init ()
    {
        m_Overlays = new List<GameObject>();
        Debug.Log(GameObject.Find("OverlayBreed"));
        m_MainOverlay = GameObject.Find("OverlayBreed");
       

        m_Overlays.Add(GameObject.Find("IncuInf0EggPanel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("BreedSetUp1Panel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("MonsterhatchingPanel").gameObject); 
        m_Overlays.Add(m_MainOverlay.transform.Find("MonsterhatchedPanel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("IncuInf1EggPanel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("IncuInf2EggPanel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("IncuInf3EggPanel").gameObject);

        for (int i = 0; i < m_Overlays.Count; i++)
        {
            m_Overlays[i].SetActive(false);
        }
        m_MainOverlay.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public GameObject GetOverlay(string _name)
    {
        GameObject panel = m_MainOverlay.transform.Find(_name).gameObject;
        if (m_Overlays.Contains(panel) == true)
        {
            if (m_OpenOverlay != null)
            {
                m_OpenOverlay.SetActive(false);
            }
           
            m_OpenOverlay = m_Overlays[m_Overlays.IndexOf(panel)];
            return m_Overlays[m_Overlays.IndexOf(panel)];
        }
        return null;
    }

    public void SetMainOverlayActive()
    {
        m_MainOverlay.SetActive(true);
    }

    public void SetOverlaysDeactive()
    {
        for (int i = 0; i < m_Overlays.Count; i++)
        {
            m_Overlays[i].SetActive(false);
        }

        m_MainOverlay.SetActive(false);
        m_OpenOverlay = null;
    }

}
