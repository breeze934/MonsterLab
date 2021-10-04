using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButton : BaseButton
{
	public string nextScence;
	[SerializeField] Animator animator;
	//[SerializeField] string secnecName;
	
	void Start(){
		this.isEnable=1;
		animator=this.GetComponent<Animator>();
		
	}
    // Update is called once per frame
    void Update()
    {
		/*
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
				SceneManager.LoadScene(scence1);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}
		*/
    }

	public void OnClick(){
	
		ChangeScence(nextScence);
	}

	public void NextScence(){
		if(nextScence!=null){
			ChangeScence(nextScence);
		}
	}
}
