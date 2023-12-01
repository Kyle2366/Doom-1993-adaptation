using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    public GameObject endGameScreen;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            button.SetActive(true);
        }

    }

    public void EndGame()
    {
        endGameScreen.SetActive(true);
        button.SetActive(false);

    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");

    }
}
