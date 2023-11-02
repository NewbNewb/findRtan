using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager I;
    public GameObject card;
    public Text timeTxt;
    public GameObject endTxt;
    float time;
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioClip match;
    public AudioSource audioSource;
    public GameObject nameTxt;
    public GameObject faildTxt;


    void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;

        int[] imeges = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        imeges = imeges.OrderBy(item => Random.Range(-1f, 1f)).ToArray();

        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float x = (i / 5) * 1.4f - 2.1f;
            float y = (i % 5) * 1.4f - 3.7f;
            newCard.transform.position = new Vector3(x, y, 0);

            string imegesName = "m" + imeges[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imegesName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 60.0f)
        {
            Time.timeScale = 0f;
            endTxt.SetActive(true);
        }
    }
    public void isMatched()
    {
        //fristCard�� secondCard �� ������
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImge = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImge)
        {
            audioSource.PlayOneShot(match);
            cardNemas();
            nameTxt.SetActive(true);
            Invoke("isMatchedname", 1f);
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                Time.timeScale = 0f;
                endTxt.SetActive(true);
                //Invoke("GameEnd", 0f);
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
            faildTxt.SetActive(true);
            Invoke("notMatchedname", 0.8f);
        }
        firstCard = null;
        secondCard = null;
    }
    public void retryGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void isMatchedname()
    {
        nameTxt.SetActive(false);
    }
    public void notMatchedname()
    {
        faildTxt.SetActive(false);
    }
    void cardNemas()
    {
        Debug.Log("�̸��� ����!");
    }



    /*void GameEnd()
    {
        Time.timeScale = 0f;
        endTxt.SetActive(true);
    }*/
}
