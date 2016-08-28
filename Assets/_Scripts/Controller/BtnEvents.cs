using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Restifizer;
using System.Text.RegularExpressions;

//Special Script for Button Events to Change Scenes

public class BtnEvents : MonoBehaviour
{
    public float delay = 5; //set public to change the value fast in the scene during testing phase

    public RestifizerManager m_RestManager;

    private bool m_isClickAllowed;    //check if a clickEvent should be allowed

    public List<GameObject> errorTxt;

    public void Start()
    {
        SetBtnClick(true);
    }

    

    public void ClickFromLoginToMenuBtn()
    {
        
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            string PW = GameObject.Find("PWInput").GetComponent<InputField>().text;
            string Mail = GameObject.Find("NickInput").GetComponent<InputField>().text;
           
            bool isMailInputOk = Utilities.IsValidEmail(Mail);
            bool isPWInputOk = Utilities.IsValidPassword(PW);
            
            SetErrorTxt(0, !isMailInputOk);
            SetErrorTxt(1, !isPWInputOk);
            SetBtnClick(true);
            if (isMailInputOk && isPWInputOk)
            {
                SetBtnClick(false);
                Debug.Log("Load Menu Page");
                
                GetComponent<LoginAPI>().Init();
                GetComponent<LoginAPI>().GetLoginResult(m_RestManager, Mail, PW);
            }
            
            
        }

    }

    

    

    public void SetErrorTxt(int _id, bool _IsActive)
    {
        errorTxt[_id].SetActive(_IsActive);
    }


    public void LoadMenuScreen()
    {
        LoadScene(delay, "MenuScreen");
    }

    public void ClickGoToMenuBtn()
    {
        
        if (m_isClickAllowed)
        {
            Debug.Log("Load Menu Page");
            SetBtnClick(false);

            StartCoroutine(LoadScene(delay, "MenuScreen"));
        }
       
    }

    public void ClickGoToRegisterBtn()
    {
        Debug.Log("Load Register Page");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            StartCoroutine(LoadScene(delay, "RegisterScreen"));
        }
        
    }

    public void ClickGoToNewGameBtn()
    {
        Debug.Log("Load New Game Page");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            StartCoroutine(LoadScene(delay, "CharaMakingScreen"));
        }

    }

    public void ClickGoToContinueBtn()
    {
        Debug.Log("Load Game Page");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            StartCoroutine(LoadScene(delay, "GameScreen"));
        }
    }


    //Logout Btn Click
    public void ClickLogoutBtn()
    {
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            if (PlayerPrefs.HasKey("UserMail"))
            {
                PlayerPrefs.DeleteKey("UserEmail");
            }
            if (PlayerPrefs.HasKey("AutoUserEmail"))
            {
                PlayerPrefs.DeleteKey("AutoUserEmail");
                PlayerPrefs.DeleteKey("AutoUserPW");
            }
            
            StartCoroutine(LoadScene(delay, "LoginScreen"));
        }
    }

    public void ClickFromMenuToSettingsBtn()
    {
        Debug.Log("Load Option Page");
        Application.LoadLevel("SettingsScreen");
    }

    public void ClickFromLoginToPWForgot()
    {
        PlayerPrefs.SetString("ForgotPWMail", GameObject.Find("NickInput").GetComponent<InputField>().text);
        Application.LoadLevel("ForgotPassword");
    }

    public void ClickExitBtn()
    {
        Debug.Log("Load Exit");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            Application.Quit();
        }
    }

    public void SetBtnClick(bool _IsClickAllowed)
    {
        m_isClickAllowed = _IsClickAllowed;
    }
    IEnumerator LoadScene(float delay, string scene)
    {
        yield return new WaitForSeconds(delay);
        Application.LoadLevel(scene);
    }


}
