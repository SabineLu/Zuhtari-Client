using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    private List<GameObject> m_ErrorTextObjs;
    private bool m_isClickAllowed;    //check if a clickEvent should be allowed

                                     
    void Start ()
    {
        m_isClickAllowed = true;
        m_ErrorTextObjs = new List<GameObject>();

        m_ErrorTextObjs.Add(GameObject.Find("PWErrorTxt"));
        m_ErrorTextObjs.Add(GameObject.Find("PW2ErrorTxt"));

        for (int i = 0; i < m_ErrorTextObjs.Count; i++)
        {
            m_ErrorTextObjs[i].SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool CheckPWInput(int _Pos, string _String)
    {
        bool check = false;
        check = Utilities.IsValidPassword(_String);
        m_ErrorTextObjs[_Pos].SetActive(!check);
        return check;
    }

    public void ClickSaveNewBtn()
    {
        string string1 = GameObject.Find("PW1Input").GetComponent<InputField>().text;
        string string2 = GameObject.Find("PW2Input").GetComponent<InputField>().text;

        if (CheckPWInput(0, string1) && CheckPWInput(1, string2))
        {
            SetBtnClick(false);
            if (Utilities.DoStringsMatch(string1, string2))
            {
                Debug.Log(GetComponent<BtnEvents>().m_RestManager);
                Debug.Log(PlayerPrefs.GetString("UserEmail"));
                Debug.Log(string1);
                m_ErrorTextObjs[1].SetActive(false);
                GetComponent<LoginAPI>().SendUpdatePW(GetComponent<BtnEvents>().m_RestManager, string1, PlayerPrefs.GetString("UserEmail"));
            }
            else
            {
                m_ErrorTextObjs[1].SetActive(true);
                SetBtnClick(true);
            }
            
        }
       
    }

    public void SetBtnClick(bool _IsClickAllowed)
    {
        m_isClickAllowed = _IsClickAllowed;
    }

}
