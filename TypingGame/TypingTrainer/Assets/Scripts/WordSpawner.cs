using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-4.5f,4.5f), 5.5f);

       GameObject wordObj = Instantiate(wordPrefab,randomPosition, Quaternion.identity, wordCanvas);
       WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
       wordDisplay.transform.SetAsFirstSibling();

        return wordDisplay;
    }
}
