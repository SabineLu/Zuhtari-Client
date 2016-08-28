using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//game manager controller which will not destroyed on opening the mini games; will manage the whole game scene
public class GameManagerController : MonoBehaviour
{
    private List<GameObject>    m_Panels;               // panels in the game screen
    private string              m_LastShownPanel;       //last shown panel
    private Vector3             m_LastShownPanelPos;    //position of panels in the game scenes

	// Use this for initialization
	void Start ()
    {
        m_Panels = new List<GameObject>();

        //get Panels from scene and add them to collection
        //TODO: find better way of finding panels by name (hardcoded names bad practise)
        m_Panels.Add(GameObject.Find("FarmPanel"));
        m_Panels.Add(GameObject.Find("BreederPanel"));
        m_Panels.Add(GameObject.Find("TownPanel"));
        m_Panels.Add(GameObject.Find("FieldPanel"));

        //standard first shown panel is farm panel
        m_LastShownPanel = "FarmPanel";
        m_LastShownPanelPos = m_Panels[m_Panels.IndexOf(GameObject.Find(m_LastShownPanel))].transform.localPosition;

        InitPanels();
    }

    //Init Panels to start position
    private void InitPanels()
    {

        // Set the Breeder Panel
        Vector3 pos = new Vector3();
        pos = m_Panels[1].transform.localPosition;
        pos.x = (Screen.width);

        m_Panels[1].transform.localPosition = pos;

        // Set Town Panel
        pos = m_Panels[2].transform.localPosition;
        pos.y = (Screen.height);

        m_Panels[2].transform.localPosition = pos;

        // Set Field Panel
        pos = m_Panels[3].transform.localPosition;
        pos.x = -(Screen.width);

        m_Panels[3].transform.localPosition = pos;
    }

    //Switch Panels
    public void SwitchPanel(int _PanelID)
    {
        m_Panels[m_Panels.IndexOf(GameObject.Find(m_LastShownPanel))].transform.localPosition = m_LastShownPanelPos;

        m_LastShownPanel = m_Panels[_PanelID].name;
        m_LastShownPanelPos = m_Panels[m_Panels.IndexOf(GameObject.Find(m_LastShownPanel))].transform.localPosition;
        m_Panels[m_Panels.IndexOf(GameObject.Find(m_LastShownPanel))].transform.localPosition = Vector3.zero;

    }
}
