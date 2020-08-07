using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour {

    public Image img_musicBtn;
    public Image img_soundBtn;

    public Sprite[] SoundOnOff;
    public Sprite[] MusicOnOff;

    
    
    private void OnEnable()
    {
        img_soundBtn.sprite = SoundOnOff[SoundManager.Instance.Sound];
        img_musicBtn.sprite = MusicOnOff[SoundManager.Instance.Music];

    }

    public void OnClickSoundToggle()
    {
        if(SoundManager.Instance.Sound == 1)
        {
            SoundManager.Instance.Sound = 0;
        }
        else
        {
            SoundManager.Instance.Sound = 1;
        }

        img_soundBtn.sprite = SoundOnOff[SoundManager.Instance.Sound];

        SoundManager.Instance.SoundsOnOff();

        PlayerPrefs.SetInt("sound", SoundManager.Instance.Sound);

    }
    public void OnClickMusicToggle()
    {
        if (SoundManager.Instance.Music == 1)
        {
            SoundManager.Instance.Music = 0;
        }
        else
        {
            SoundManager.Instance.Music = 1;
        }

        img_musicBtn.sprite = MusicOnOff[SoundManager.Instance.Music];

        SoundManager.Instance.MusicsOnOff();

        PlayerPrefs.SetInt("music", SoundManager.Instance.Music);

    }

}
