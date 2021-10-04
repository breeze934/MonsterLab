using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButtom : MonoBehaviour
{
    delegate void SetValue(int x,int y);
    SetValue setValue;
    public int buttomNo;
    private GameData gameData;
    private int flag; 
    void Start()
    {
        gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
        flag = 0;
        setValue=new SetValue(gameData.SetPara);
    }
    public void OnClick(){
        if(flag!=0){
            flag = 0;
            
        }else{
            flag = 1;
        }
        print("setValue:"+buttomNo+" flag:"+flag);
        setValue(buttomNo,flag);
    }

    public int getFlag(){
        return flag;
    }
}
