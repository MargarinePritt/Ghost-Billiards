using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]public int currentBall=-1;
    [HideInInspector]public List<int> ballList=new List<int>();

    [SerializeField]private GameObject ball;

    [SerializeField]private GameObject player0;
    [SerializeField]private GameObject player1;

    [HideInInspector]public int player0Score=0;
    [HideInInspector]public int player1Score=0;
    public TMP_Text player0ScoreText;
    public TMP_Text player1ScoreText;

    private bool gameStart=false;
    [HideInInspector]public bool gameOver=false;

    [SerializeField]private GameObject logo;
    [SerializeField]private GameObject start;
    [SerializeField]private GameObject howToPlay;
    [SerializeField]private GameObject hTP;

    [SerializeField]private TMP_Text theWinnerIs;
    [SerializeField]private Button replay;

	private void Awake()
	{
		if(instance==null){
            instance=this;
        }
        else{
            Destroy(gameObject);
        }
	}

	// Start is called before the first frame update
	void Start()
    {
        theWinnerIs.gameObject.SetActive(false);
        replay.gameObject.SetActive(false);

        for(int i=1;i<=5;i++){
            ballList.Add(i);
        }
        currentBall=ballList[0];
        Debug.Log("currentBall = "+currentBall);

        player0ScoreText.text=player0Score.ToString();
        player1ScoreText.text=player1Score.ToString();
    }

	private void Update()
	{
        if(!gameStart){
            ball.SetActive(false);
            player0.SetActive(false);
            player1.SetActive(false);
            player0ScoreText.gameObject.SetActive(false);
            player1ScoreText.gameObject.SetActive(false);
        }
        else{
            ball.SetActive(true);
            player0.SetActive(true);
            player1.SetActive(true);
            player0ScoreText.gameObject.SetActive(true);
            player1ScoreText.gameObject.SetActive(true);

            logo.SetActive(false);
            start.SetActive(false);
            howToPlay.SetActive(false);
        }

		if(gameOver){
            player0ScoreText.gameObject.SetActive(false);
            player1ScoreText.gameObject.SetActive(false);
            theWinnerIs.gameObject.SetActive(true);
            replay.gameObject.SetActive(true);

            if(player0Score>player1Score){
                player0.transform.position=new Vector3(0,0,0);
                player1.SetActive(false);
            }
            else{
                player1.transform.position=new Vector3(0,0,0);
                player0.SetActive(false);
            }
        }
	}

    public void StartGame(){
        gameStart=true;
    }

    public void ShowHTP(){
        hTP.SetActive(true);
    }

    public void CloseHTP(){
        hTP.SetActive(false);
    }

    public void Replay(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
