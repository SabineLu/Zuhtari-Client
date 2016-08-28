using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

//controller for register scene
public class RegisterScreenController : MonoBehaviour
{
    private UserModel           m_User;             //User model
    private InputField          m_Name;             //input object for name
    private InputField          m_Email;            //email input object
    private InputField          m_Email2;           //input object for email recheck
    private InputField          m_PW;               //input object for password
    private bool                m_IsClickAllowed;   //token for click events

    private List<GameObject>    m_ExistTextObject;  //text object collection, if name or email already exist in the db show error

    private int                 m_Counter;          //check counter for inputs

    // Use this for initialization
    void Start () {

        m_User              = new UserModel();
        m_Counter           = 0;
        m_ExistTextObject   = new List<GameObject>();

        //TODO: remove hardcoded names of objects
        m_ExistTextObject.Add(GameObject.Find("NameExistTxt"));
        m_ExistTextObject.Add(GameObject.Find("EmailExistTxt"));

        //hide text message objects
        for (int i = 0; i < m_ExistTextObject.Count; i++)
        {
            SetActiveExistTextObject(i, false);
        }

        //allow click events
        m_IsClickAllowed = true;
    }

    //click event for going back to login from register
    public void ClickFromRegisterToLogin()
    {
       
        if (m_IsClickAllowed)
        {
            SetBtnClick(false);
            m_Counter   = 0;
            //get all input objects
            m_Name      = GameObject.Find("UserNameInputField").GetComponent<InputField>();
            m_Email     = GameObject.Find("EmailInputField").GetComponent<InputField>();
            m_Email2    = GameObject.Find("Email2InputField").GetComponent<InputField>();
            m_PW        = GameObject.Find("PWInputField").GetComponent<InputField>();

            //set user model
            m_User.setName(m_Name.text);
            m_User.setEmail(m_Email.text);
            m_User.setPassword(m_PW.text);

            //set color of input field to red if error on the input happened, white if all is ok
            ColorBlock cb;
            if (Utilities.CheckCharacterCount(m_Name.text, 3))
            {
                cb = m_Name.colors;
                cb.normalColor = Color.white;
                m_Name.colors = cb;
                m_Counter += 1;
            }
            else
            {
                cb = m_Name.colors;
                cb.normalColor = Color.red;
                m_Name.colors = cb;
            }

            if (Utilities.IsValidEmail(m_Email.text))
            {
                cb = m_Email.colors;
                cb.normalColor = Color.white;
                m_Email.colors = cb;
                m_Counter += 1;
            }
            else
            {
                cb = m_Email.colors;
                cb.normalColor = Color.red;
                m_Email.colors = cb;
            }

            if (Utilities.IsValidEmail(m_Email2.text))
            {
                cb = m_Email2.colors;
                cb.normalColor = Color.white;
                m_Email2.colors = cb;
                m_Counter += 1;

                //check if both email fields match
                if (Utilities.DoStringsMatch(m_Email.text, m_Email2.text))
                {
                    cb = m_Email.colors;
                    cb.normalColor = Color.white;
                    m_Email.colors = cb;

                    cb = m_Email2.colors;
                    cb.normalColor = Color.white;
                    m_Email2.colors = cb;
                    m_Counter += 1;
                }
                else
                {
                    cb = m_Email.colors;
                    cb.normalColor = Color.red;
                    m_Email.colors = cb;

                    cb = m_Email2.colors;
                    cb.normalColor = Color.red;
                    m_Email2.colors = cb;

                }
            }
            else
            {
                cb = m_Email2.colors;
                cb.normalColor = Color.red;
                m_Email2.colors = cb;
            }

            if (Utilities.CheckCharacterCount(m_PW.text, 6))
            {
                cb = m_PW.colors;
                cb.normalColor = Color.white;
                m_PW.colors = cb;
                m_Counter += 1;
            }
            else
            {
                cb = m_PW.colors;
                cb.normalColor = Color.red;
                m_PW.colors = cb;
            }


            SetBtnClick(true);

            //check if all inputs were ok
            if (m_Counter == 5)
            {
                SetBtnClick(false);
                Debug.Log("All Inputs Are fine!");
                //send request to server to add new user
                GetComponent<LoginAPI>().GetRegisterResult(GetComponent<BtnEvents>().m_RestManager, m_User);
            }
        }
        
    }

    //de-/activate text object
    public void SetActiveExistTextObject(int _Pos, bool _active)
    {
        m_ExistTextObject[_Pos].SetActive(_active);
    }

    //de-/activate btn click token
    public void SetBtnClick(bool _IsClickAllowed)
    {
        m_IsClickAllowed = _IsClickAllowed;
    }

    //return to login page without register user
    public void ClickCancelBtn()
    {
        if (m_IsClickAllowed)
        {
           Application.LoadLevel("LoginScreen");
        }        
    }


}
