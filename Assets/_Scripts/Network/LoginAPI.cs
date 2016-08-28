using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Restifizer;

public class LoginAPI : MonoBehaviour
{
    Hashtable m_Parameters = new Hashtable();
    RestifizerResponse m_Response = null;


    public void Init()
    {

        
    }

    public void ActivateRecivedResponse()
    {
        
    }

    public void GetLoginResult(RestifizerManager manager, string username, string password)
    {
        m_Parameters.Clear();

        m_Parameters.Add("username", username);
        m_Parameters.Add("password", password);
        manager.ResourceAt("api/db/user/namepassword").Post(m_Parameters, (response) => {
            m_Response = response;
            if (m_Response != null)
            {
                Debug.Log("user found");
                GetComponent<BtnEvents>().SetErrorTxt(2, false);
                Debug.Log("LoginAPI " + response.ToString());
                if (GetComponent<LoginScreenController>().GetToogleSaveLogin())
                {
                    PlayerPrefs.SetString("UserEmail", username);
                    PlayerPrefs.SetString("AutoUserEmail", username);
                    PlayerPrefs.SetString("AutoUserPW", password);
                }
                else
                {
                    PlayerPrefs.SetString("UserEmail", username);
                }
                Application.LoadLevel("MenuScreen");

            } else
            {
                Debug.Log("No user found");
                GetComponent<BtnEvents>().SetBtnClick(true);
                GetComponent<BtnEvents>().SetErrorTxt(2, true);
                GetComponent<BtnEvents>().SetErrorTxt(3, true);
            }
        });

    }

    public void GetRegisterResult(RestifizerManager manager, UserModel _User)
    {
        m_Parameters.Clear();
 
        m_Parameters.Add("username", _User.getName());
        m_Parameters.Add("email", _User.getEmail());
        m_Parameters.Add("password", _User.getPassword());
        manager.ResourceAt("api/db/user/sendNewUser").Post(m_Parameters, (response) => {
            m_Response = response;

            if (m_Response.Status == 200)
            {
                Application.LoadLevel("LoginScreen");
            }
            else if (m_Response.Status == 409)
            {
                
                GetComponent<RegisterScreenController>().SetActiveExistTextObject(0, false);
                GetComponent<RegisterScreenController>().SetActiveExistTextObject(1, true);
            }
            else if(m_Response.Status == 408)
            {
                GetComponent<RegisterScreenController>().SetActiveExistTextObject(0, true);
                GetComponent<RegisterScreenController>().SetActiveExistTextObject(1,false);
            }
            GetComponent<RegisterScreenController>().SetBtnClick(true);
        });
    }

    public void SendMailForNewPW(RestifizerManager manager, string mail)
    {
        Debug.Log(mail);
        m_Parameters.Clear();

        m_Parameters.Add("mail", mail);
        manager.ResourceAt("api/db/user/sendNewPWMailAndUpdateUser").Post(m_Parameters, (response) => {
            m_Response = response;
            Debug.Log(response);

            if (m_Response != null)
            {
                Debug.Log("user found");
                PlayerPrefs.DeleteKey("ForgotPWMail");
                GetComponent<PasswordForgotScreenController>().SetMailWasSendScreen();
                
            }
            else
            {
                Debug.Log("No user found");
                GetComponent<PasswordForgotScreenController>().SetMailFailed();

            }
        });

    }

    public void SendUpdatePW(RestifizerManager _Manager, string _PW,string _Mail)
    {
        m_Parameters.Clear();

        m_Parameters.Add("pw", _PW);
        m_Parameters.Add("mail",_Mail);
        _Manager.ResourceAt("api/db/user/sendNewInputPWAndUpdateUser").Post(m_Parameters, (response) => {
            m_Response = response;
            if (m_Response != null)
            {
                if (PlayerPrefs.HasKey("AutoUserMail"))
                {
                    PlayerPrefs.SetString("AutoUserPW", _PW);
                }

            }
            else
            {
                Debug.Log("Save Failed");

            }
        });
    }

}
