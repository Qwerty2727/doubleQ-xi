using UnityEngine;
using System.Collections;

public class ChangeMusic : MonoBehaviour
{
	public AudioClip menuMusic;
	public AudioClip level2Music;
	public AudioClip level3Music;
	public AudioClip level4Music;
	
	private AudioSource source;
	
	
	// Use this for initialization
	void Awake () 
	{
		source = GetComponent<AudioSource>();
	}
	
	
	void OnLevelWasLoaded(int level)
	{
		switch (level)
		{
		case 1:
			source.clip = menuMusic;
			source.Play ();
			break;
		case 3:
			source.clip = level2Music;
			source.Play ();
			break;
		case 4:
			source.clip = level3Music;
			source.Play ();
			break;
		case 5:
			source.clip = level4Music;
			source.Play ();
			break;
		default:
			break;
		}
	}
}