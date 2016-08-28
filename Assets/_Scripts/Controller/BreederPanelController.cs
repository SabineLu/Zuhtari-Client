using UnityEngine;
using System.Collections;
using Assets._Scripts.Controller;

//Class Controller for the Breeding Panel in the Game Scene
//TODO: Add show Attention Icons on/off at Nests
//TODO: Rework the Setup of the Incubator Panel as the images on it change via code
//TODO: Remove Placeholder Incubator Panels from scene
public class BreederPanelController : MonoBehaviour
{
    private BreederPanelModel       m_BreederPanel;   //Model object for the breeding panel
    private CreatePictureController m_PicCreateController;  //TODO: check if obselete class call

	// Use this for initialization
	void Start () {
        m_BreederPanel = new BreederPanelModel();
        m_BreederPanel.Init();

        m_PicCreateController = new CreatePictureController();
        m_PicCreateController.Init();
	}

    //Click  Incubator Nest to show overlay information
    public void IncubatorInfoClick(int _Index)
    {
        m_BreederPanel.SetMainOverlayActive();  //set main overlay active
        m_BreederPanel.GetOverlay("IncuInf"+ _Index + "EggPanel").SetActive(true);  //show specific overlay panel placeholder
    }

    //Click event for showing Breeding Option Overlay Panel
    public void BreedBtnClick()
    {
        m_BreederPanel.GetOverlay("BreedSetUp1Panel").SetActive(true);
    }

    //Click event for Attention Hatch Icon on the Nest shown
    public void HatchingWarningBtnClick()
    {
        Debug.Log("Click the warning");
        m_BreederPanel.SetMainOverlayActive(); //set main overlay active
        m_BreederPanel.GetOverlay("MonsterhatchingPanel").SetActive(true); //show hatching overlay
    }

    //Click event when let egg being hatched
    public void HatchedBtnClick()
    {
        //TODO: Remove Warning ICON from FrontEnd
        //TODO: Add New Data to the DB Server
        m_BreederPanel.GetOverlay("MonsterhatchedPanel").SetActive(true);   //show hatched overlay
    }

    //Click event for oracle button
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

    //close hatched overlay after checking name input for new pet
    public void CloseHatchlingOverlay()
    {
        //TODO:Check Input for Monster Name
        CloseOverlay();
    }

    //close breeder overlay
    public void CloseOverlay()
    {
        m_BreederPanel.SetOverlaysDeactive();
    }

}
