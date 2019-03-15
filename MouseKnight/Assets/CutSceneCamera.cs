using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCamera : MonoBehaviour
{
    public GameObject cam1, cam2, cam3;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutScene());
    }

    IEnumerator CutScene()
    {
        yield return new WaitForSeconds(2f);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(2f);
        cam3.SetActive(true);
        cam2.SetActive(false);

    }
    
}
