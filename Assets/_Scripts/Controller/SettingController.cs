using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

//controller for user setting page, access through the menu scene
public class SettingController : MonoBehaviour
{
    private List<GameObject>    m_ErrorTextObjs;   //Error Text objects in the scene
    private bool                m_isClickAllowed;  //check if a clickEvent should be allowed

         
    //init function                            
    void Start ()
    {
        m_isClickAllowed        = true;    //Allow click events
        m_ErrorTextObjs         = new List<GameObject>();

        //Find and Add Scene Objects for Error Texts in the collection
        m_ErrorTextObjs.Add(GameObject.Find("PWErrorTxt"));
        m_ErrorTextObjs.Add(GameObject.Find("PW2ErrorTxt"));

        //Set all Error Objects to inactive
        for (int i = 0; i < m_ErrorTextObjs.Count; i++)
        {
            m_ErrorTextObjs[i].SetActive(false);
        }

    }

    //check password input fields
    public bool CheckPWInput(int _Pos, string _String)
    {
        bool check = false;
        check = Utilities.IsValidPassword(_String);
        m_ErrorTextObjs[_Pos].SetActive(!check);
        return check;
    }

    // click button to save new password
    public void ClickSaveNewBtn()
    {
        if (m_isClickAllowed)
        {
            //Get Input field text
            string string1 = GameObject.Find("PW1Input").GetComponent<InputField>().text;
            string string2 = GameObject.Find("PW2Input").GetComponent<InputField>().text;

            //Only allow Server Communication if Fields are correctly set up and both PWs match
            if (CheckPWInput(0, string1) && CheckPWInput(1, string2))
            {
                SetBtnClick(false);
                if (Utilities.DoStringsMatch(string1, string2))
                {
                   m_ErrorTextObjs[1].SetActive(false);
                   //Call function for communication with server to update UserData with new PW
                   GetComponent<LoginAPI>().SendUpdatePW(GetComponent<BtnEvents>().m_RestManager, string1, PlayerPrefs.GetString("UserEmail"));
                }
                else
                {

                    m_ErrorTextObjs[1].SetActive(true); //Show error message
                    SetBtnClick(true); //allow click events
                }

            }
        }       
    }

    //Set Click Event bool
    public void SetBtnClick(bool _IsClickAllowed)
    {
        m_isClickAllowed = _IsClickAllowed;
    }

}
