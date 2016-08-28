using UnityEngine;
using System.Collections;

public class FarmPanelController : MonoBehaviour {

    private FarmPanelModel m_FarmPanel;

    // Use this for initialization
    void Start () {
        m_FarmPanel = new FarmPanelModel();
        m_FarmPanel.Init();
    }
	
	 public void MonsterInfoClick()
    {
        m_FarmPanel.SetMainOverlayActive();
        m_FarmPanel.GetOverlay("MonsterPanel").SetActive(true);
    }

    public void PlayerOverlayClick()
    {
        m_FarmPanel.SetMainOverlayActive();
        m_FarmPanel.GetOverlay("PlayerPanel").SetActive(true);
        m_FarmPanel.GetPlayerLayer("FarmInfoPanel").SetActive(true);
    }

    public void FarmLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("FarmInfoPanel").SetActive(true);
    }

    public void MarketLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("MarketInfoPanel").SetActive(true);
    }

    public void MonsterBookLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("MonsterBookInfoPanel").SetActive(true);
    }

    public void GameStatisticLayerBtnClick()
    {
        m_FarmPanel.GetPlayerLayer("GameStatisticInfoPanel").SetActive(true);
    }

    public void CloseOverlay()
    {
        m_FarmPanel.SetOverlaysDeactive();
    }

}
