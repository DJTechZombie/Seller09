using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacle : MonoBehaviour
    {
    [SerializeField]
    float rotSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rotSpeed = Random.Range(-1, 1) * 15;

    }

    // Update is called once per frame
    void Update()
    {
        if (rotSpeed == 0)
        {
            rotSpeed = Random.Range(-1, 1) * 15;
        }
        float rotation = rotSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}
