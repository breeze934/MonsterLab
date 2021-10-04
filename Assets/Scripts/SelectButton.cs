using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    delegate void SetValue(int x,int y);
    SetValue setValue;
    public int buttonNo;
    private GameData gameData;
    private int flag; 
    Image image;
    void Awake()
    {
        gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        flag = 0;
        if(gameData!=null){
            setValue=new SetValue(gameData.SetPara);
        }
        
    }
    public void OnClick(){
        if(flag!=0){
            flag = 0;
            setColor(Color.white);
        }else{
            flag = 1;
            setColor(Color.black);
        }
        setValue(buttonNo,flag);
        
    }
    public int getFlag(){
        return flag;
    }
    private void setColor(Color color){
        this.GetComponent<Image>().color=color;
    }
}
