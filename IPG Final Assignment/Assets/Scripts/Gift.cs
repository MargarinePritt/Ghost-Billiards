using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField]private AudioClip giftPop;
    [SerializeField]private AudioClip giftBounce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver){
            Destroy(gameObject);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag=="Gift"){
            GetComponent<AudioSource>().clip=giftBounce;
            GetComponent<AudioSource>().Play();
        }
	}
}
