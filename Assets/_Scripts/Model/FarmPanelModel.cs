using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FarmPanelModel {

    private GameObject m_MainOverlay;
    private List<GameObject> m_Overlays;
    private List<GameObject> m_PlayerOverlays;

    private GameObject m_OpenOverlay;
    private GameObject m_OpenPlayerOverlay;
    // Use this for initialization
    public void Init()
    {
        m_Overlays = new List<GameObject>();
        m_PlayerOverlays = new List<GameObject>();

        m_MainOverlay = GameObject.Find("OverlayFarm");


        m_Overlays.Add(GameObject.Find("MonsterPanel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("PlayerPanel").gameObject);

        m_PlayerOverlays.Add(GameObject.Find("FarmInfoPanel").gameObject);
        m_PlayerOverlays.Add(GameObject.Find("MarketInfoPanel").gameObject);
        m_PlayerOverlays.Add(GameObject.Find("MonsterBookInfoPanel").gameObject);
        m_PlayerOverlays.Add(GameObject.Find("GameStatisticInfoPanel").gameObject);

        for (int i = 0; i < m_Overlays.Count; i++)
        {
            m_Overlays[i].SetActive(false);
        }

        for (int i = 0; i < m_PlayerOverlays.Count; i++)
        {
            m_PlayerOverlays[i].SetActive(false);
        }

        m_MainOverlay.SetActive(false);
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

    public GameObject GetPlayerLayer(string _name)
    {
        GameObject panel = null;

        for (int i = 0; i < m_PlayerOverlays.Count; i++)
        {
            if (m_PlayerOverlays[i].name == _name)
            {
                panel = m_PlayerOverlays[i];
                break;

            }
        }

        if (m_PlayerOverlays.Contains(panel) == true)
        {
            if (m_OpenPlayerOverlay != null)
            {
                m_OpenPlayerOverlay.SetActive(false);
            }

            m_OpenPlayerOverlay = m_PlayerOverlays[m_PlayerOverlays.IndexOf(panel)];
            return m_PlayerOverlays[m_PlayerOverlays.IndexOf(panel)];
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

    public void SetPlayerLaysDeactive()
    {
        for (int i = 0; i < m_PlayerOverlays.Count; i++)
        {
            m_PlayerOverlays[i].SetActive(false);
        }

        m_MainOverlay.SetActive(false);
        m_OpenPlayerOverlay = null;
    }
}
