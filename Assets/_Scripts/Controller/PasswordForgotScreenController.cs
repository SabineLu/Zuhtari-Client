using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using Restifizer;

//Controller Class for Password retrieve scene
public class PasswordForgotScreenController : MonoBehaviour
{
    private List<GameObject>    m_TxtFields;        //collection of text objects objects
    private List<GameObject>    m_Buttons;          //collection of buttons on scene
    private GameObject          m_InputMail;        //input object on scene for mail

    private bool                m_isClickAllowed;   //check if a clickEvent should be allowed

    public RestifizerManager    m_RestManager;      //REST Manager for Communication with server

    // Use this for initialization
    void Start ()
    {
        m_isClickAllowed    = true;    //check if a clickEvent should be allowed

        //set input object
        m_InputMail         = GameObject.Find("MailInput");
        //set local saved mail input from login page intp password forgot mail input
        m_InputMail.GetComponent<InputField>().text = PlayerPrefs.GetString("ForgotPWMail");

        //delete local key
        PlayerPrefs.DeleteKey("ForgotPWMail");

        //add buttons to collection
        m_Buttons = new List<GameObject>();

        m_Buttons.Add(GameObject.Find("CancelBtn"));
        m_Buttons.Add(GameObject.Find("SendMailBtn"));
        m_Buttons.Add(GameObject.Find("OkBtn"));

        m_Buttons[2].SetActive(false);

        //add text objects to collections and hide them
        m_TxtFields = new List<GameObject>();

        m_TxtFields.Add(GameObject.Find("MailErrorTxt"));
        m_TxtFields.Add(GameObject.Find("MailSendErrorTxt"));
        m_TxtFields.Add(GameObject.Find("MailSendOkTxt"));

        for (int i = 0; i < m_TxtFields.Count; i++)
        {
            m_TxtFields[i].SetActive(false);
        }

    }

    //from password forgot scene to login page
    public void ClickFromPWForgotToLogin()
    {
        Application.LoadLevel("LoginScreen");
    }
    
    //send request for new password out after checking the fields
    public void ClickSendMailForNewPWBtn()
    {

        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            string Mail = GameObject.Find("MailInput").GetComponent<InputField>().text;

            //check if Email is ok
            bool isMailInputOk = Utilities.IsValidEmail(Mail);
            
            //error message shown if Mail was incorrect set
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
    
    //De-/Activate text object
    public void SetTxtObject(int _ID, bool _IsActive)
    {
        m_TxtFields[_ID].SetActive(_IsActive);
    }

    //De-/Activate button object
    public void SetBtnObject(int _ID, bool _IsActive)
    {
        m_Buttons[_ID].SetActive(_IsActive);
    }

    //De-/Activate button click events
    public void SetBtnClick(bool _IsActive)
    {
        m_isClickAllowed = _IsActive;
    }

    //Mail/password failed to be send/saved shown
    public void SetMailFailed()
    {
       SetTxtObject(1, true);
       SetBtnClick(true);
    }

    //Show information that server send mail out to user (Mail cant be changed)
    public void SetMailWasSendScreen()
    {
        SetTxtObject(1, false);
        SetTxtObject(2, true);
        SetBtnObject(0, false);
        SetBtnObject(1, false);
        SetBtnObject(2, true);
        SetReadOnlyForInput();
    }

    //change state of input object
    public void SetReadOnlyForInput()
    {
        m_InputMail.GetComponent<InputField>().readOnly =true;
    }
}
