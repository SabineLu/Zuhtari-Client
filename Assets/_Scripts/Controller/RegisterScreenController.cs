using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RegisterScreenController : MonoBehaviour
{
    UserModel m_User;
    InputField m_Name;
    InputField m_Email;
    InputField m_Email2;
    InputField m_PW;
    bool m_IsClickAllowed;

    private List<GameObject> m_ExistTextObject;

    int Counter;

    // Use this for initialization
    void Start () {

        m_User = new UserModel();
        Counter = 0;
        m_ExistTextObject = new List<GameObject>();

        m_ExistTextObject.Add(GameObject.Find("NameExistTxt"));
        m_ExistTextObject.Add(GameObject.Find("EmailExistTxt"));

        for (int i = 0; i < m_ExistTextObject.Count; i++)
        {
            SetActiveExistTextObject(i, false);
        }
        m_IsClickAllowed = true;
    }

    public void ClickFromRegisterToLogin()
    {
       
        if (m_IsClickAllowed)
        {
            SetBtnClick(false);
            Counter = 0;
            m_Name = GameObject.Find("UserNameInputField").GetComponent<InputField>();
            m_Email = GameObject.Find("EmailInputField").GetComponent<InputField>();
            m_Email2 = GameObject.Find("Email2InputField").GetComponent<InputField>();
            m_PW = GameObject.Find("PWInputField").GetComponent<InputField>();

            m_User.setName(m_Name.text);
            m_User.setEmail(m_Email.text);
            m_User.setPassword(m_PW.text);

            ColorBlock cb;
            if (Utilities.CheckCharacterCount(m_Name.text, 3))
            {
                cb = m_Name.colors;
                cb.normalColor = Color.white;
                m_Name.colors = cb;
                Counter += 1;
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
                Counter += 1;
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
                Counter += 1;

                if (Utilities.DoStringsMatch(m_Email.text, m_Email2.text))
                {
                    cb = m_Email.colors;
                    cb.normalColor = Color.white;
                    m_Email.colors = cb;

                    cb = m_Email2.colors;
                    cb.normalColor = Color.white;
                    m_Email2.colors = cb;
                    Counter += 1;
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
                Counter += 1;
            }
            else
            {
                cb = m_PW.colors;
                cb.normalColor = Color.red;
                m_PW.colors = cb;
            }


            SetBtnClick(true);
            if (Counter == 5)
            {
                SetBtnClick(false);
                Debug.Log("All Inputs Are fine!");
                GetComponent<LoginAPI>().GetRegisterResult(GetComponent<BtnEvents>().m_RestManager, m_User);
            }
        }
        
    }

    public void SetActiveExistTextObject(int _Pos, bool _active)
    {
        m_ExistTextObject[_Pos].SetActive(_active);
    }

    public void SetBtnClick(bool _IsClickAllowed)
    {
        m_IsClickAllowed = _IsClickAllowed;
    }

    public void ClickCancelBtn()
    {
        if (m_IsClickAllowed)
        {
           Application.LoadLevel("LoginScreen");
        }        
    }


}
