using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]private int goalNo=-1;

    public int collisionBallNo=-1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag=="Ball"){
            collisionBallNo=collision.gameObject.GetComponent<Ball>().ballNo;

            if(collisionBallNo==GameManager.instance.currentBall){
                if(goalNo==0){
                    GameManager.instance.player1Score++;
                    GameManager.instance.player1ScoreText.text=GameManager.instance.player1Score.ToString();
                }
                else if(goalNo==1){
                    GameManager.instance.player0Score++;
                    GameManager.instance.player0ScoreText.text=GameManager.instance.player0Score.ToString();
                }
            }
            else{
                if(goalNo==0){
                    GameManager.instance.player0Score++;
                    GameManager.instance.player0ScoreText.text=GameManager.instance.player0Score.ToString();
                }
                else if(goalNo==1){
                    GameManager.instance.player1Score++;
                    GameManager.instance.player1ScoreText.text=GameManager.instance.player1Score.ToString();
                }
            }

            if(GameManager.instance.ballList.Count>1){
                GameManager.instance.ballList.Remove(collisionBallNo);
                GameManager.instance.currentBall=GameManager.instance.ballList[0];
                Debug.Log("currentBall = "+GameManager.instance.currentBall);
            }
            else{
                GameManager.instance.gameOver=true;
            }

            Destroy(collision.gameObject);
        }
	}
}
