using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Farm Panel Data Class
public class FarmPanelModel
{

    private GameObject          m_MainOverlay;      //Main overlay for farm panel
    private List<GameObject>    m_Overlays;         //under overlays on top of main overlay
    private List<GameObject>    m_PlayerOverlays;   //sepcific player overlays for player

    private GameObject          m_OpenOverlay;      //opened overlay
    private GameObject          m_OpenPlayerOverlay;//opened overlay of player info

    // Use this for initialization
    public void Init()
    {
        m_Overlays          = new List<GameObject>();
        m_PlayerOverlays    = new List<GameObject>();


        //TODO: remove hardcoded object names
        //assign Mainoverlay
        m_MainOverlay       = GameObject.Find("OverlayFarm");

        //assign overlays on top of main ovelray (monster info and player info)
        m_Overlays.Add(GameObject.Find("MonsterPanel").gameObject);
        m_Overlays.Add(m_MainOverlay.transform.Find("PlayerPanel").gameObject);

        //assign player specific information overlays 
        m_PlayerOverlays.Add(GameObject.Find("FarmInfoPanel").gameObject);
        m_PlayerOverlays.Add(GameObject.Find("MarketInfoPanel").gameObject);
        m_PlayerOverlays.Add(GameObject.Find("MonsterBookInfoPanel").gameObject);
        m_PlayerOverlays.Add(GameObject.Find("GameStatisticInfoPanel").gameObject);

        //set all overlays deactive
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

    //get specific overlay with name
     public GameObject GetOverlay(string _Name)
    {
        GameObject panel = m_MainOverlay.transform.Find(_Name).gameObject;

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

    //get player layer with name of layer
    public GameObject GetPlayerLayer(string _Name)
    {
        GameObject panel = null;

        for (int i = 0; i < m_PlayerOverlays.Count; i++)
        {
            if (m_PlayerOverlays[i].name == _Name)
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


    //Activate main overlay
    public void SetMainOverlayActive()
    {
        m_MainOverlay.SetActive(true);
    }

    //set overlays deactive (hide them)
    public void SetOverlaysDeactive()
    {
        for (int i = 0; i < m_Overlays.Count; i++)
        {
            m_Overlays[i].SetActive(false);
        }

        m_MainOverlay.SetActive(false);
        m_OpenOverlay = null;
    }

    //set player overlays deactive
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
