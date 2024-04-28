using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField]private Sprite fever0;
    [SerializeField]private Sprite fever1;
    [SerializeField]private Sprite fever2;
    private int spriteIndex=0;

	private void Update()
	{
        int spriteIndexModulo=spriteIndex%3;
		switch(spriteIndexModulo){
            case 0:
                GetComponent<SpriteRenderer>().sprite=fever0;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite=fever1;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite=fever2;
                break;
        }
	}

    public void StartFeverAnimation(){
        StartCoroutine(FeverAnimation());
    }

	public IEnumerator FeverAnimation(){
        yield return new WaitForSeconds(0.5f);
        spriteIndex++;
        StartCoroutine(FeverAnimation());
    }
}
