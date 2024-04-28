using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollider : MonoBehaviour
{
    private bool scaleBonus=false;
    private bool speedBonus=false;
    private bool scoreFever=false;

    private float scaleTimer=0f;
    private float speedTimer=0f;
    private float scoreTimer=0f;

    [SerializeField]private float duration=10f;

    [SerializeField]private GameObject goalL;
    [SerializeField]private GameObject goalR;

    [SerializeField]private AudioClip giftGet;

    [SerializeField]private GameObject fever;
    private bool startFeverAnimation=false;
    private bool feverAnimationStarted=false;

    void Update()
    {
        if(scaleBonus){
            if(scaleTimer>0f){
                transform.localScale=new Vector3(2,2,2);
                scaleTimer-=Time.deltaTime;
            }
            else{
                scaleTimer=0f;
                transform.localScale=new Vector3(1,1,1);
                scaleBonus=false;
            }
        }

        if(speedBonus){
            if(speedTimer>0f){
                GetComponent<Movement>().speed=1000f;
                speedTimer-=Time.deltaTime;
            }
            else{
                speedTimer=0f;
                GetComponent<Movement>().speed=500f;
                speedBonus=false;
            }
        }

        if(scoreFever){
            if(scoreTimer>0f){
                goalL.GetComponent<Goal>().scoreCoefficient=2;
                goalR.GetComponent<Goal>().scoreCoefficient=2;
                GameManager.instance.fever.SetActive(true);
                if(!startFeverAnimation&&!feverAnimationStarted){
                    startFeverAnimation=true;
                    StartFeverAnimation();
                    feverAnimationStarted=true;
                }
                scoreTimer-=Time.deltaTime;
            }
            else{
                scoreTimer=0f;
                goalL.GetComponent<Goal>().scoreCoefficient=1;
                goalR.GetComponent<Goal>().scoreCoefficient=1;
                startFeverAnimation=false;
                feverAnimationStarted=false;
                GameManager.instance.fever.SetActive(false);
                scoreFever=false;
            }
        }
    }

    private void StartFeverAnimation(){
        if(startFeverAnimation){
            fever.GetComponent<Fever>().StartFeverAnimation();
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag=="Gift"){
            int randomNum=Random.Range(0,3);
            if(randomNum==0){
                scaleBonus=true;
                scaleTimer=duration;
            }
            else if(randomNum==1){
                speedBonus=true;
                speedTimer=duration;
            }
            else if(randomNum==2){
                scoreFever=true;
                scoreTimer=duration;
            }
            GetComponent<AudioSource>().clip=giftGet;
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
	}
}
