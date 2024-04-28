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
	public GameObject fever;

    private bool gameStart=false;
    [HideInInspector]public bool gameOver=false;

    [SerializeField]private GameObject startMenu;
    [SerializeField]private GameObject hTP;
    [SerializeField]private GameObject endMenu;

    [SerializeField]private GameObject gift;
    private float giftSpawnCoefficient=1.5f;
    private float giftSpawnTimer=0f;

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
        startMenu.SetActive(true);
        hTP.SetActive(false);
        endMenu.SetActive(false);

        for(int i=1;i<=5;i++){
            ballList.Add(i);
        }
        currentBall=ballList[0];

        player0ScoreText.text=player0Score.ToString();
        player1ScoreText.text=player1Score.ToString();

		ball.SetActive(false);
		player0.SetActive(false);
		player1.SetActive(false);
		player0ScoreText.gameObject.SetActive(false);
		player1ScoreText.gameObject.SetActive(false);
		fever.SetActive(false);
    }

	private void Update()
	{
		if (gameStart) {
			ball.SetActive(true);
			player0.SetActive(true);
			player1.SetActive(true);
			player0ScoreText.gameObject.SetActive(true);
			player1ScoreText.gameObject.SetActive(true);

			startMenu.SetActive(false);

			StartCoroutine(GiftSpawn());

			gameStart=false;
		}

		if (gameOver) {
			player0ScoreText.gameObject.SetActive(false);
			player1ScoreText.gameObject.SetActive(false);
			fever.SetActive(false);
			endMenu.SetActive(true);
			player0.transform.localScale=new Vector3(1,1,1);
			player1.transform.localScale=new Vector3(1,1,1);

			if(player0Score>player1Score){
				player0.transform.position=new Vector3(0, 0, 0);
				player1.SetActive(false);
			}
			else if(player0Score<player1Score){
				player1.transform.position=new Vector3(0, 0, 0);
				player0.SetActive(false);
			}
			else if(player0Score==player1Score){
				player0.transform.position=new Vector3(-1,0,0);
				player1.transform.position=new Vector3(1,0,0);
			}
		}

		giftSpawnTimer+=giftSpawnCoefficient*Time.deltaTime;
	}

	private IEnumerator GiftSpawn()
	{
		if(!gameOver){
			yield return new WaitForSeconds(1);
			int giftSpawnProbability = Random.Range(0, 101);
			if (giftSpawnProbability < giftSpawnTimer) {
				float spawnX=Random.Range(-4,4);
				float spawnY=Random.Range(-3,3);
				Instantiate(gift,new Vector3(spawnX,spawnY,0),Quaternion.identity);
				giftSpawnTimer = 0;
			}
			StartCoroutine(GiftSpawn());
		}
	}

	public void StartGame(){
        gameStart=true;
		GetComponent<AudioSource>().Play();
    }

    public void ShowHTP(){
        hTP.SetActive(true);
		GetComponent<AudioSource>().Play();
    }

    public void CloseHTP(){
        hTP.SetActive(false);
		GetComponent<AudioSource>().Play();
    }

    public void Replay(){
		GetComponent<AudioSource>().Play();
		Invoke("ReloadScene",0.1f);
    }

	private void ReloadScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
