using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]private int goalNo=-1;

    public int collisionBallNo=-1;
    public int scoreCoefficient=1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag=="Ball"){
            GetComponent<AudioSource>().Play();
            collisionBallNo=collision.gameObject.GetComponent<Ball>().ballNo;

            if(collisionBallNo==GameManager.instance.currentBall){
                if(goalNo==0){
                    GameManager.instance.player1Score+=1*scoreCoefficient;
                    GameManager.instance.player1ScoreText.text=GameManager.instance.player1Score.ToString();
                }
                else if(goalNo==1){
                    GameManager.instance.player0Score+=1*scoreCoefficient;
                    GameManager.instance.player0ScoreText.text=GameManager.instance.player0Score.ToString();
                }
            }
            else{
                if(goalNo==0){
                    GameManager.instance.player0Score+=1*scoreCoefficient;
                    GameManager.instance.player0ScoreText.text=GameManager.instance.player0Score.ToString();
                }
                else if(goalNo==1){
                    GameManager.instance.player1Score+=1*scoreCoefficient;
                    GameManager.instance.player1ScoreText.text=GameManager.instance.player1Score.ToString();
                }
            }

            if(GameManager.instance.ballList.Count>1){
                GameManager.instance.ballList.Remove(collisionBallNo);
                GameManager.instance.currentBall=GameManager.instance.ballList[0];
            }
            else{
                GameManager.instance.gameOver=true;
            }

            Destroy(collision.gameObject);
        }
	}
}
