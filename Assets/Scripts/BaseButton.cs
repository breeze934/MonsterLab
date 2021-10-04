using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseButton : MonoBehaviour
{
    protected int flag;
    private int _isEnable;
    Color unselectedColor=Color.white;
    Color selectedColor=Color.grey;
    protected Image image;
    // Start is called before the first frame update
    void Start()
    {
        InitImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int isEnable
    {
        set{_isEnable=value;}
        get{return _isEnable;}
    }

    public void ChangeColor(){
        if(_isEnable==1){
            if(flag==1){
                flag=0;
                image.color = unselectedColor;
            }else{
                flag=1;
                image.color = selectedColor;
            }
        }else{
            //button is disable;do nothing
        }

    }

    public void SetColor(){
        if(_isEnable==1){
            if(flag==0){
                //print("clear color");
                image.color = unselectedColor;
            }else{
                //print("set color");
                image.color = selectedColor;
            }
        }else{
            //button is disable;do nothing
        }
    }


    public void ChangeScence(string scenceName){
        //print(scenceName+" "+_isEnable);
        if(_isEnable==1){
            SceneManager.LoadScene(scenceName);
        }else{
            //button is disable;do nothing
        }
    }

    protected void InitImage(){
        //print("init image");

        flag=0;
        _isEnable=1;
        image=this.GetComponent<Image>();
        image.color = unselectedColor;
    }

    protected void LoadImage(Sprite buttonImage)
    {
        image=this.GetComponent<Image>();
        image.color = unselectedColor;
        image.sprite =buttonImage;
    }

    public void DestroyObj(string objName)
    {
        GameObject obj=GameObject.Find(objName);
        if(obj !=null)
        {
            Destroy(obj);
        }
        
    }
}
