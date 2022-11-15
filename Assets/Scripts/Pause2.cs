using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ingameMenu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPause()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }
    public void OnResume()
    {
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }
    public void OnRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
}
