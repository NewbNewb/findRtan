using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBtn : MonoBehaviour
{
    public AudioClip asd;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStartBtn()
    {
        audioSource.PlayOneShot(asd);
        Invoke("gameStart", 0.3f);
        
    }
    public void gameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
