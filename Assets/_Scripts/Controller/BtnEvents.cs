using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Restifizer;
using System.Text.RegularExpressions;

//Special Script for Button Events to Change Scenes
//TODO: Check if this Class is not Obselete for future use

public class BtnEvents : MonoBehaviour
{
    public float m_Delay = 5; //set public to change the value fast in the scene during testing phase

    public RestifizerManager m_RestManager;

    private bool m_isClickAllowed;    //check if a clickEvent should be allowed

    public List<GameObject> m_ErrorTxt;   //Error Text Onjects in Scene 

    //Init
    public void Start()
    {
        SetBtnClick(true);  //allow click events
    }

    
    //Login Button Click events from Login to Menu
    public void ClickFromLoginToMenuBtn()
    {
        
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            //Get inputs
            string PW = GameObject.Find("PWInput").GetComponent<InputField>().text;
            string Mail = GameObject.Find("NickInput").GetComponent<InputField>().text;
           
            //check inputs
            bool isMailInputOk = Utilities.IsValidEmail(Mail);
            bool isPWInputOk = Utilities.IsValidPassword(PW);
            
            //set error objects active
            SetErrorTxt(0, !isMailInputOk);
            SetErrorTxt(1, !isPWInputOk);
            SetBtnClick(true);

            //check if inputs were ok
            if (isMailInputOk && isPWInputOk)
            {
                SetBtnClick(false);
                Debug.Log("Load Menu Page");
                
                //Call loginAPI to communicate with Server to login
                GetComponent<LoginAPI>().Init();
                GetComponent<LoginAPI>().GetLoginResult(m_RestManager, Mail, PW);
            }
            
            
        }

    }
    
    //De-/Activate Error Text Objects
    public void SetErrorTxt(int _ID, bool _IsActive)
    {
        m_ErrorTxt[_ID].SetActive(_IsActive);
    }

    //Go to Menu Scene without delay (the yield wont work since no StartCoroutine is set)
    public void LoadMenuScreen()
    {
        LoadScene(m_Delay, "MenuScreen");
    }

    //Go to Menu Screens after specific set delay
    public void ClickGoToMenuBtn()
    {
        
        if (m_isClickAllowed)
        {
            Debug.Log("Load Menu Page");
            SetBtnClick(false);

            StartCoroutine(LoadScene(m_Delay, "MenuScreen"));
        }
       
    }

    //Go to Register Screens after specific set delay
    public void ClickGoToRegisterBtn()
    {
        Debug.Log("Load Register Page");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            StartCoroutine(LoadScene(m_Delay, "RegisterScreen"));
        }
        
    }

    //Go to Character Making Screens after specific set delay
    public void ClickGoToNewGameBtn()
    {
        Debug.Log("Load New Game Page");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            StartCoroutine(LoadScene(m_Delay, "CharaMakingScreen"));
        }

    }

    //Go to Game Screens after specific set delay
    public void ClickGoToContinueBtn()
    {
        Debug.Log("Load Game Page");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            StartCoroutine(LoadScene(m_Delay, "GameScreen"));
        }
    }


    //Logout Btn Click
    public void ClickLogoutBtn()
    {
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            //Delete the local set variables of user for login
            if (PlayerPrefs.HasKey("UserMail"))
            {
                PlayerPrefs.DeleteKey("UserEmail");
            }
            if (PlayerPrefs.HasKey("AutoUserEmail"))
            {
                PlayerPrefs.DeleteKey("AutoUserEmail");
                PlayerPrefs.DeleteKey("AutoUserPW");
            }
            
            StartCoroutine(LoadScene(m_Delay, "LoginScreen"));
        }
    }

    //Go to Setting Screens after specific set delay
    public void ClickFromMenuToSettingsBtn()
    {
        Debug.Log("Load Option Page");
        Application.LoadLevel("SettingsScreen");
    }

    //Go to Forgot PW Screens after specific set delay
    public void ClickFromLoginToPWForgot()
    {
        PlayerPrefs.SetString("ForgotPWMail", GameObject.Find("NickInput").GetComponent<InputField>().text);
        Application.LoadLevel("ForgotPassword");
    }

    //Close APP
    //TODO: close app completle as it is still running in BG on Mobile
    public void ClickExitBtn()
    {
        Debug.Log("Load Exit");
        if (m_isClickAllowed)
        {
            SetBtnClick(false);
            Application.Quit();
        }
    }

    //de-/ activate click events
    public void SetBtnClick(bool _IsClickAllowed)
    {
        m_isClickAllowed = _IsClickAllowed;
    }

    //load specific scene after some delay
    IEnumerator LoadScene(float _Delay, string _Scene)
    {
        yield return new WaitForSeconds(_Delay);
        Application.LoadLevel(_Scene);
    }
    
}
