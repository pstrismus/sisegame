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
        muteButton.image.sprite = (backgroundMusic.mute == false) ? muteImage : unmuteImage;
        backgroundMusic.mute = !backgroundMusic.mute;
    }
}
