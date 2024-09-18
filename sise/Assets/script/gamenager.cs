using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class gamenager : MonoBehaviour
{
    public static gamenager instance = null;
    
    public GameObject[] rafObjects;
    public List<List<GameObject>> listelistesi;
    private Canvas playgame;
    public GameObject player1;
    public GameObject player2;
    public GameObject mevcutPlayer;
    public GameObject winUI;
    public TextMeshProUGUI winUItext;
    public GameObject kazanan;
    [SerializeField]TextMeshProUGUI player1GUI;
    [SerializeField]TextMeshProUGUI player2GUI;

    public AIbot Bot = AIbot.instance;
    public bool BotActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        BotActive = (PlayerPrefs.GetInt("BotActive") == 1) ? true : false;
        player1 = GameObject.FindGameObjectWithTag("player1");
        player2 = GameObject.FindGameObjectWithTag("player2");
        rafObjects = GameObject.FindGameObjectsWithTag("raf");
        mevcutPlayer = player1;
        player2.SetActive(false);
        playerName();
    }

    public void setPlayer()
    {
        if (mevcutPlayer == player1&&buttonclick.instance.sayıı>1)
        {
            mevcutPlayer.SetActive(false);
            mevcutPlayer = player2;
            mevcutPlayer.SetActive(true);
            if (BotActive)
            {
                StartCoroutine(Timer());
            }

        }
        else if(mevcutPlayer == player2 && buttonclick.instance.sayıı > 1)
        {
            mevcutPlayer.SetActive(false);
            mevcutPlayer = player1;
            mevcutPlayer.SetActive(true);
        }
    }
    public void control()
    {
        if (buttonclick.instance.sayıı == 0)
        {
            kazanan = (mevcutPlayer == player1) ? player2 : player1;
        }
        if (buttonclick.instance.sayıı == 1 && buttonclick.instance.isdelete == false)
        {
            DeleteObjectsWithTag("sise");
            kazanan = (mevcutPlayer == player1) ? player1 : player2;
        }
    }
    public void DeleteObjectsWithTag(string tag)
    {
       
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    public void player()
    {
        control();
        if (buttonclick.instance.sayıı == 0|| buttonclick.instance.sayıı == 1)
        {
            if (kazanan == null)
            {
                kazanan = mevcutPlayer;
            }
            player1.SetActive(false);
            player2.SetActive(false);
            winUI.SetActive(true);
            winUItext.text = kazanan.GetComponent<players>().playerName;
        }
        
    }
    public void resetGame()
    {
        SceneManager.LoadScene(0);
    }
    void playerName()
    {
        player1GUI.text =PlayerPrefs.GetString("Player1");
        player2GUI.text =PlayerPrefs.GetString("Player2");
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        Bot.BotMove();
    }

}
