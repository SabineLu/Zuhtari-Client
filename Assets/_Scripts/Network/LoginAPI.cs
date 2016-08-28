using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Restifizer;

//Login API communication for client to server
public class LoginAPI : MonoBehaviour
{
    private Hashtable           m_Parameters    = new Hashtable();      //Hashtable for parameters send tot he server
    private RestifizerResponse  m_Response      = null;                 //recived response from server

    public void Init()
    { }

    //send login data to server and await response
    public void GetLoginResult(RestifizerManager _Manager, string _Username, string _Password)
    {
        m_Parameters.Clear();

        m_Parameters.Add("username", _Username);
        m_Parameters.Add("password", _Password);

        _Manager.ResourceAt("api/db/user/namepassword").Post(m_Parameters, (response) => {
            m_Response = response;
            //server send response
            if (m_Response != null)
            {
                Debug.Log("user found");
                GetComponent<BtnEvents>().SetErrorTxt(2, false);
                Debug.Log("LoginAPI " + response.ToString());
                //if user choose to save login data set extra local variables
                if (GetComponent<LoginScreenController>().GetToogleSaveLogin())
                {
                    PlayerPrefs.SetString("UserEmail", _Username);
                    PlayerPrefs.SetString("AutoUserEmail", _Username);
                    PlayerPrefs.SetString("AutoUserPW", _Password);
                }
                else
                {
                    PlayerPrefs.SetString("UserEmail", _Username);
                }
                //go to menu screen
                Application.LoadLevel("MenuScreen");

            } else //no response recived
            {
                Debug.Log("No user found");
                //REMOVE BtnEvents (set these chaneg object active in different class)
                GetComponent<BtnEvents>().SetBtnClick(true);
                GetComponent<BtnEvents>().SetErrorTxt(2, true);
                GetComponent<BtnEvents>().SetErrorTxt(3, true);
            }
        });

    }

    //send register data to server to make new user in database
    public void GetRegisterResult(RestifizerManager _Manager, UserModel _User)
    {
        m_Parameters.Clear();
 
        //add data to hashtable
        m_Parameters.Add("username", _User.getName());
        m_Parameters.Add("email", _User.getEmail());
        m_Parameters.Add("password", _User.getPassword());

        //send data
        _Manager.ResourceAt("api/db/user/addNewUser").Post(m_Parameters, (response) => {
            m_Response = response;
            if (m_Response  != null)
            {
                if (m_Response.Status == 200)
                {
                    Application.LoadLevel("LoginScreen");
                }
                else if (m_Response.Status == 409)  //email was found already in db
                {

                    GetComponent<RegisterScreenController>().SetActiveExistTextObject(0, false);
                    GetComponent<RegisterScreenController>().SetActiveExistTextObject(1, true);
                }
                else if (m_Response.Status == 408)   //name was already found in db
                {
                    GetComponent<RegisterScreenController>().SetActiveExistTextObject(0, true);
                    GetComponent<RegisterScreenController>().SetActiveExistTextObject(1, false);
                }
            }
            //user was added
           
            //allow btn click
            GetComponent<RegisterScreenController>().SetBtnClick(true);
        });
    }

    //send request on server for new password
    public void SendMailForNewPW(RestifizerManager _Manager, string _Mail)
    {
        m_Parameters.Clear();

        //add data to hashtable
        m_Parameters.Add("mail", _Mail);

        //send request to server and await for response
        _Manager.ResourceAt("api/db/user/sendNewPWMailAndUpdateUser").Post(m_Parameters, (response) => {
            m_Response = response;


            if (m_Response != null)
            {
                //user foudn and user data was updated, email send to user
                Debug.Log("user found");
                PlayerPrefs.DeleteKey("ForgotPWMail");
                GetComponent<PasswordForgotScreenController>().SetMailWasSendScreen();
                
            }
            else
            {
                //could not find user, show error text
                Debug.Log("No user found");
                GetComponent<PasswordForgotScreenController>().SetMailFailed();

            }
        });

    }

    //send request to server to update the user password
    public void SendUpdatePW(RestifizerManager _Manager, string _PW,string _Mail)
    {
        m_Parameters.Clear();

        //add data to hashtable
        m_Parameters.Add("pw", _PW);
        m_Parameters.Add("mail",_Mail);

        //send request to server
        _Manager.ResourceAt("api/db/user/sendNewInputPWAndUpdateUser").Post(m_Parameters, (response) => {
            m_Response = response;
            if (m_Response != null)
            {
                if (PlayerPrefs.HasKey("AutoUserMail"))
                {
                    //set new pw in the local auto login data
                    PlayerPrefs.SetString("AutoUserPW", _PW);
                }

            }
            else
            {
                //TODO: show error text that save failed
                Debug.Log("Save Failed");

            }
        });
    }

}
