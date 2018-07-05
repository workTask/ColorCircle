using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


	public static AudioClip _jumpSound, _bumSound;

	private static AudioSource _audioSource;
	// Use this for initialization
	void Start ()
	{
		_jumpSound = Resources.Load<AudioClip>("jump");
		_bumSound = Resources.Load<AudioClip>("bum");

		_audioSource = GetComponent<AudioSource>();

	}
	
	public static void playSound(string audioClip){
		{
			switch (audioClip)
			{
				case "jump":
					_audioSource.PlayOneShot(_jumpSound);
					break;
				case "bum":
					_audioSource.PlayOneShot(_bumSound);
					break;
			}
		}
	}
}
