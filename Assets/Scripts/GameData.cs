using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //public SelectButton[] selectbutton;
    public static int bottonNumber=6;
    public static int[] k=new int[bottonNumber];
    private int audioFlag;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //k1=button1.getFlag();
       // k2=button2.getFlag();
        //k3=button3.getFlag();
        //k4=button4.getFlag();
        //k5=button5.getFlag();
        //k6=button6.getFlag();

    }
    public void SetPara(int buttonNo,int x){
        print("buttonNo:"+buttonNo+" x:"+x);
        k[buttonNo]=x;
    }

    public int GetPara(int buttonNo)
    {
        return k[buttonNo];
    }

    public void LoadButton(int buttonNo)
    {

    }

    public void ClearPara()
    {
        for(int i =0;i<bottonNumber;i++)
        {
            k[i]=0;
        }
    }
    
}
