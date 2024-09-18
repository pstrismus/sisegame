using UnityEngine;
using UnityEngine.SceneManagement;

public class players : MonoBehaviour
{
    public static players instance = null;
    public string playerName;

    private void Awake()
    { 
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {

        if (CompareTag("player1"))
        {
            playerName = PlayerPrefs.GetString("Player1");
        }
        else if (CompareTag("player2"))
        {
            playerName = PlayerPrefs.GetString("Player2");
        }

        Debug.Log("Oyuncu ismi yüklendi: " + playerName);
    }
}
