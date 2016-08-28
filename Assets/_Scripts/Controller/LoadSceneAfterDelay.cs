using UnityEngine;
using System.Collections;

//Load Login Screen After Delay
//Class is used with splashscreen scene as Unity free does not let user change Splashscreen
public class LoadSceneAfterDelay : MonoBehaviour
{

    public float    m_Delay             = 5;                //delay seconds
    public string   m_NewLevelString    = "LoginScreen";    //load login scene

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadLevelAfterDelay(m_Delay));
    }
	
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        Debug.Log("Load Login Page");
        yield return new WaitForSeconds(delay);
        Application.LoadLevel(m_NewLevelString);
    }
}
