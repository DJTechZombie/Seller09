using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    private int nextScene;

    private MouseKnightController mk;
    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            Debug.Log("Current Scene:" + SceneManager.GetActiveScene().name);
            nextScene = 0;
        }
        else
        {
            Debug.Log("Current Scene:" + SceneManager.GetActiveScene().name);
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        }
        mk = FindObjectOfType<MouseKnightController>();
    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name == "TeaserScene")
        {
            if (Input.GetMouseButtonDown(0))
            {
                LoadMenu();
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (mk != null)
            {
                if (Input.GetMouseButtonDown(0))
                    {
                        if(mk.isDead)
                        {
                           
                        }
                        else
                        {
                            LoadNextScene();
                        }
                    }
            }
            else
                if (Input.GetMouseButtonDown(0))
            {
                LoadNextScene();
            }
        }
            }
    public void ButtonLoad()
    {
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void reLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
