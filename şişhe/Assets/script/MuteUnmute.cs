using UnityEngine;
using UnityEngine.UI;

public class MuteUnmute : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Button muteButton;
    public Sprite muteImage;
    public Sprite unmuteImage;
    private bool isMuted = false;

    void Start()
    {
        muteButton.onClick.AddListener(ToggleMute);
    }

    void ToggleMute()
    {
        if (isMuted)
        {
            backgroundMusic.mute = false;
            isMuted = false;
            muteButton.image.sprite = muteImage;  // Mute resmini değiştir
        }
        else
        {
            backgroundMusic.mute = true;
            isMuted = true;
            muteButton.image.sprite = unmuteImage;  // Unmute resmini değiştir
        }
    }
}
