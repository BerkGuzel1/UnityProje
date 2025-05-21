using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AudioToggle : MonoBehaviour
{
    public Button muteButton;
    public TMP_Text muteButtonText;

    private bool isMuted = false;

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        UpdateAudio();
        muteButton.onClick.AddListener(ToggleSound);
    }

    void ToggleSound()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        UpdateAudio();
    }

    void UpdateAudio()
    {
        AudioListener.volume = isMuted ? 0f : 1f;
        muteButtonText.text = isMuted ? "Voice On" : "Voice Off";
    }
}
