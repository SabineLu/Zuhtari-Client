using UnityEngine;
using System.Collections;
using Assets._Scripts.Controller;

public class BreederPanelController : MonoBehaviour
{
    private BreederPanelModel m_BreederPanel;
    private CreatePictureController m_PicCreateController;

	// Use this for initialization
	void Start () {
        m_BreederPanel = new BreederPanelModel();
        m_BreederPanel.Init();

        m_PicCreateController = new CreatePictureController();
        m_PicCreateController.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncubatorInfoClick(int _Index)
    {
        m_BreederPanel.SetMainOverlayActive();
        //m_BreederPanel.GetOverlay("IncuInfPanel").SetActive(true);
        m_BreederPanel.GetOverlay("IncuInf"+ _Index + "EggPanel").SetActive(true);
    }

    public void BreedBtnClick()
    {
        m_BreederPanel.GetOverlay("BreedSetUp1Panel").SetActive(true);
    }

    public void HatchingWarningBtnClick()
    {
        Debug.Log("Click the warning");
        m_BreederPanel.SetMainOverlayActive();
        m_BreederPanel.GetOverlay("MonsterhatchingPanel").SetActive(true);
    }

    public void HatchedBtnClick()
    {
        //TODO: Remove Warning ICON from FrontEnd
        //TODO: Add New Data to the DB Server
        m_BreederPanel.GetOverlay("MonsterhatchedPanel").SetActive(true);
    }

    public void OracleBtnClick()
    {
        //TODO: Add Save New Data to Monster BOOK
        //TODO: Get Color Data from Server 

        //call Pic Maker Function and Make 4 Random Pictures 
        //TODO:Btn Click Permission needs to be checked on Panel
        if (true)
        {
            m_PicCreateController.Test();
        }
       


    }

    public void CloseHatchlingOverlay()
    {
        //TODO:Check Input for Monster Name
        CloseOverlay();
    }

    public void CloseOverlay()
    {
        m_BreederPanel.SetOverlaysDeactive();
    }

}
