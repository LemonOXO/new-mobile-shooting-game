using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void OnResume()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
