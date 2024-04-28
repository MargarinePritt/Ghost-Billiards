using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballNo;

	[SerializeField]private AudioClip ballBounce;
	[SerializeField]private AudioClip giftBounce;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag=="Ball"||collision.gameObject.tag=="Frame"){
			GetComponent<AudioSource>().clip=ballBounce;
			GetComponent<AudioSource>().Play();
		}
		else if(collision.gameObject.tag=="Gift"){
			GetComponent<AudioSource>().clip=giftBounce;
			GetComponent<AudioSource>().Play();
		}
	}
}
