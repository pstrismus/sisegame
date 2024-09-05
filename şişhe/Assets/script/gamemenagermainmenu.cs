using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gamemenagermainmenu : MonoBehaviour
{
    public TMP_InputField player1Input;
    public TMP_InputField player2Input;
    [SerializeField]GameObject player1Bos;
    [SerializeField] GameObject player2Bos;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
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
        }
    }
}
