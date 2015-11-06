using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour
{
	public GameObject LoadImage;
	public void LoadScene(int level)
	{
		LoadImage.SetActive (true);
		Application.LoadLevel (level);
	}
}
