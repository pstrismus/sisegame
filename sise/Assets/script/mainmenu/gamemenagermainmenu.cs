using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gamemenagermainmenu : MonoBehaviour
{
    enum screen { giris, secim, kullanıcı }
    [SerializeField] screen Currentscreen;
    
    [SerializeField] GameObject girisUI;
    [SerializeField] GameObject secimUI;
    [SerializeField] GameObject kullanıcıUI;

    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    [SerializeField]GameObject player1Bos;
    [SerializeField] GameObject player2Bos;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void IleriButon()
    {
        switch (Currentscreen)
        {
            case screen.giris:
                secimUI.SetActive(true);
                girisUI.SetActive(false);
                Currentscreen = screen.secim;
                break;
            case screen.secim:
                kullanıcıUI.SetActive(true);
                secimUI.SetActive(false);
                Currentscreen = screen.kullanıcı;
                break;
        }
    }
    public void GeriButon()
    {
        switch (Currentscreen)
        {
            case screen.secim:
                secimUI.SetActive(false);
                girisUI.SetActive(true);
                Currentscreen = screen.giris;
                break;
            case screen.kullanıcı:
                kullanıcıUI.SetActive(false);
                secimUI.SetActive(true);
                Currentscreen = screen.secim;
                break;
        }
    }
    public void StartButton()
    {
        string input = "   "; // Kontrol etmek istedi�iniz string

        // String sadece bo�luklardan olu�uyorsa ya da tamamen bo�sa
        if (string.IsNullOrWhiteSpace(player1Input.text.Trim()))
        {
            player1Bos.SetActive(true);
        }
        else if(!PlayerPrefs.HasKey("Player2"))
        {
            PlayerPrefs.SetString("Player1", player1Input.text); 
        }

        if (string.IsNullOrWhiteSpace(player2Input.text.Trim()))
        {
            player2Bos.SetActive(true);
        }
        else if(!PlayerPrefs.HasKey("Player2"))
        {
            PlayerPrefs.SetString("Player2", player2Input.text);
        }
        if (PlayerPrefs.HasKey("Player2") && PlayerPrefs.HasKey("Player1"))
        {
            SceneManager.LoadScene(1);
            PlayerPrefs.SetInt("BotActive", 0);
        }

    }
    public void StartButtonBot()
    {
        PlayerPrefs.SetString("Player1", "SİZ");
        PlayerPrefs.SetString("Player2", "BOT");
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("BotActive", 1);
    }
}
