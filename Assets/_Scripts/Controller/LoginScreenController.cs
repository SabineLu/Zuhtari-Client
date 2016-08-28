using UnityEngine;
using UnityEngine.UI;

public class LoginScreenController : MonoBehaviour
{
    private bool m_ToogleSaveLogin;
	// Use this for initialization
	void Start ()
    {
        m_ToogleSaveLogin = true;

        if (PlayerPrefs.HasKey("AutoUserEmail"))
        {
            GameObject.Find("PWInput").GetComponent<InputField>().text = PlayerPrefs.GetString("AutoUserPW");
            GameObject.Find("NickInput").GetComponent<InputField>().text = PlayerPrefs.GetString("AutoUserEmail");
            GameObject.Find("Canvas").GetComponent<BtnEvents>().ClickFromLoginToMenuBtn();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToogledRememberLogin()
    {
        m_ToogleSaveLogin = !m_ToogleSaveLogin;
    }

    public bool GetToogleSaveLogin()
    {
        return m_ToogleSaveLogin;
    }
}
