using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using Restifizer;

public class PasswordForgotScreenController : MonoBehaviour
{
    private List<GameObject> m_TxtFields;
    private List<GameObject> m_Buttons;
    private GameObject m_InputMail;

    private bool m_isClickAllowed;    //check if a clickEvent should be allowed

    public RestifizerManager m_RestManager;

    // Use this for initialization
    void Start ()
    {
        m_isClickAllowed = true;    //check if a clickEvent should be allowed

        m_InputMail = GameObject.Find("MailInput");
        m_InputMail.GetComponent<InputField>().text = PlayerPrefs.GetString("ForgotPWMail");

        PlayerPrefs.DeleteKey("ForgotPWMail");

        m_Buttons = new List<GameObject>();

        m_Buttons.Add(GameObject.Find("CancelBtn"));
        m_Buttons.Add(GameObject.Find("SendMailBtn"));
        m_Buttons.Add(GameObject.Find("OkBtn"));

        m_Buttons[2].SetActive(false);

        m_TxtFields = new List<GameObject>();

        m_TxtFields.Add(GameObject.Find("MailErrorTxt"));
        m_TxtFields.Add(GameObject.Find("MailSendErrorTxt"));
        m_TxtFields.Add(GameObject.Find("MailSendOkTxt"));

        for (int i = 0; i < m_TxtFields.Count; i++)
        {
            m_TxtFields[i].SetActive(false);
        }

    }

    public void ClickFromPWForgotToLogin()
    {
        Application.LoadLevel("LoginScreen");
    }
    
    public void ClickSendMailForNewPWBtn()
    {

        if (m_isClickAllowed)
        {
            Debug.Log("ClickSendMailForNewPWBtn");
            SetBtnClick(false);
            string Mail = GameObject.Find("MailInput").GetComponent<InputField>().text;

            bool isMailInputOk = Utilities.IsValidEmail(Mail);

            Debug.Log(isMailInputOk);
            SetTxtObject(0, !isMailInputOk);
           
            SetBtnClick(true);
            if (isMailInputOk)
            {
                SetBtnClick(false);
                Debug.Log("Send Mail");
                
                //recheck with server
                GetComponent<LoginAPI>().Init();
                GetComponent<LoginAPI>().SendMailForNewPW(m_RestManager, Mail);
            }


        }

    }


   

    public void SetTxtObject(int _id, bool _IsActive)
    {
        m_TxtFields[_id].SetActive(_IsActive);
    }


    public void SetBtnObject(int _id, bool _IsActive)
    {
        m_Buttons[_id].SetActive(_IsActive);
    }

    public void SetBtnClick(bool _IsActive)
    {
        m_isClickAllowed = _IsActive;
    }

    public void SetMailFailed()
    {
       SetTxtObject(1, true);
       SetBtnClick(true);
    }

    public void SetMailWasSendScreen()
    {
        SetTxtObject(1, false);
        SetTxtObject(2, true);
        SetBtnObject(0, false);
        SetBtnObject(1, false);
        SetBtnObject(2, true);
        SetReadOnlyForInput();
    }

    public void SetReadOnlyForInput()
    {
        m_InputMail.GetComponent<InputField>().readOnly =true;
    }
}
