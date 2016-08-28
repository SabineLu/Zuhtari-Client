using UnityEngine;
using System.Collections;

//Farm Panel Controller for the Farm Panel (Place User can reach the mini games)
public class FarmPanelController : MonoBehaviour
{

    private FarmPanelModel m_FarmPanel;

    //initialization
    void Start ()
    {
        m_FarmPanel = new FarmPanelModel(); 
        m_FarmPanel.Init();
    }
	
    //Show overlay for monster information on the farm screen
	 public void MonsterInfoClick()
    {
        m_FarmPanel.SetMainOverlayActive();
        m_FarmPanel.GetOverlay("MonsterPanel").SetActive(true);
    }

    //show overlay for the player information on the farm screen
    //player overlay will always have farm info as start shown
    public void PlayerOverlayClick()
    {
        m_FarmPanel.SetMainOverlayActive();
        m_FarmPanel.GetOverlay("PlayerPanel").SetActive(true);
        m_FarmPanel.GetPlayerLayer("FarmInfoPanel").SetActive(true);
    }

    //Get Farm Info overlay shown
    public void FarmLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("FarmInfoPanel").SetActive(true);
    }

    //Get market Info overlay shown
    public void MarketLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("MarketInfoPanel").SetActive(true);
    }

    //Get monster book Info overlay shown
    public void MonsterBookLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("MonsterBookInfoPanel").SetActive(true);
    }

    //Get statistik Info overlay shown
    public void GameStatisticLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("GameStatisticInfoPanel").SetActive(true);
    }

    //close overlay
    public void CloseOverlay()
    {
        m_FarmPanel.SetOverlaysDeactive();
    }

}
