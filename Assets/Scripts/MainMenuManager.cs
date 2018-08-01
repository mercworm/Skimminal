using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public GameObject introText;
    Animator textAnim;
    public float waitTime;
    
    // Use this for initialization
	void Start () {
        textAnim = introText.GetComponent<Animator>();
        StartCoroutine(TextFade());
	}
	
    public IEnumerator TextFade ()
    {
        yield return new WaitForSeconds(waitTime);
        textAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EdwardsRoom");
    }
}
