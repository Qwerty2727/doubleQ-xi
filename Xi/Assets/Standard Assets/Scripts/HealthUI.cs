using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUI : MonoBehaviour
{
	public int health = 9999;
	public Text healthGameObject;
	// Use this for initialization
	void Start ()
	{
		health = PlayerPrefs.GetInt("savedHealth");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(health < 10)
		{
			healthGameObject.text = "000" + health;
		}
		else
		{
			if(health < 100)
			{
				healthGameObject.text = "00" + health;
			}
			else
			{
				if(health < 1000)
				{
					healthGameObject.text = "0" + health;
				}
				else
				{
					if(health > 9999)
					{
						health = 9999;
					}
					else
					{
						healthGameObject.text = "" + health;
					}
				}
			}
		}
	}
}
