using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{

    
    public void UserClickButton()
    {
        SceneManager.LoadScene("Main");
        
    }
}
