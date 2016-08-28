using UnityEngine;
using System.Collections;

public class LoadSceneAfterDelay : MonoBehaviour
{

    public float delay = 5;
    public string newLevelString= "LoginScreen";

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }
	
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        Debug.Log("Load Login Page");
        yield return new WaitForSeconds(delay);
        Application.LoadLevel(newLevelString);
    }
}
