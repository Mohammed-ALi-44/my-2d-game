using UnityEngine;
using UnityEngine.Audio ;
using UnityEngine.UI ;

public class Volume : MonoBehaviour 
{
	[SerializeField] AudioMixer myMixer;
	[SerializeField] Slider musicSlider;
	void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
			LoadVolume();
        }
        else
        {
			SetMusicVolume();
        }
    }
	public void SetMusicVolume()
    {
		float volume = musicSlider.value;
		myMixer.SetFloat("music",Mathf.Log10(volume)*20);
		PlayerPrefs.SetFloat("musicVolume", volume);

    }
	void LoadVolume()
    {
		musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
		SetMusicVolume();
    }

	
	
}
