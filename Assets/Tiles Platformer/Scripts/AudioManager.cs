using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{	[Header("+++AudioSource+++")]
	[SerializeField] AudioSource musicSource;
	[Header("music")]
	public AudioClip backGround;
	



	void Start()
    {
		musicSource.clip = backGround;
		musicSource.Play();
    }
	

	
}
