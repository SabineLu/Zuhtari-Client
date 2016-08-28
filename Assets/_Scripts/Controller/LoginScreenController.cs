using UnityEngine;
using UnityEngine.UI;

//Controller for the Loing Scene
public class LoginScreenController : MonoBehaviour
{
    private bool m_ToogleSaveLogin;     // bool for toogle of the automatic login setting

	// Use this for initialization
	void Start ()
    {
        m_ToogleSaveLogin = true;

        //automaticly let user be logged in if local variables are found
        //TODO: function should be moved to splashscreen rather
        if (PlayerPrefs.HasKey("AutoUserEmail"))
        {
            GameObject.Find("PWInput").GetComponent<InputField>().text = PlayerPrefs.GetString("AutoUserPW");
            GameObject.Find("NickInput").GetComponent<InputField>().text = PlayerPrefs.GetString("AutoUserEmail");
            GameObject.Find("Canvas").GetComponent<BtnEvents>().ClickFromLoginToMenuBtn();
        }
	}

    //De- / Activate toogle
    public void ToogledRememberLogin()
    {
        m_ToogleSaveLogin = !m_ToogleSaveLogin;
    }

    //return the state of auto login toogle
    public bool GetToogleSaveLogin()
    {
        return m_ToogleSaveLogin;
    }
}
