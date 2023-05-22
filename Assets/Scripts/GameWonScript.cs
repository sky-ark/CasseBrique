using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonScript : MonoBehaviour
{
    public static int BricksAtBeginning;

    public static int DestroyedBrick;
    // Start is called before the first frame update
    void Start()
    {
        DestroyedBrick = 0;
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Brick");
        BricksAtBeginning = objectsWithTag.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyedBrick == BricksAtBeginning)
        {
            Debug.Log("You WON");
            SceneManager.LoadScene("WinScene");
        }
    }
}
