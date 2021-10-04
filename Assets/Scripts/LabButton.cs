using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabButton : BaseButton
{
    LabManagement labManagement;
    //public int buttonNum;
    protected int labNum;
    //public int temperature,humidity,foodChain,height,cleanness,risk,breadth;
    
    private int[] para;
    // Start is called before the first frame update
    void Start()
    {
        InitImage();
        labManagement=GameObject.Find("LabManagement").GetComponent<LabManagement>();
        //labManagement.RegLabHolder(buttonNum,this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        if(labNum>=0)
        {
            //ChangeColor();
            if(flag == 1){
                labManagement.ClearLabFlag(labNum);
                flag = 0;
            }else{
                labManagement.SetLabFlag(labNum);
                flag =1;
            }
        
        }else
        {

        }
        SetColor();
        
    }
    /*
    public int GetLabPara(int ParaNo){
        return para[ParaNo];
    }
    */
    public void LoadButtonResource(LabParameter myPara)
    {
        Transform child=this.GetComponent<Transform>().Find("LabName");
        Text buttonName=child.GetComponent<Text>();
        buttonName.text=myPara.labName;
        labNum = myPara.LabNum;
        //print("flag is "+myPara.Flag);
        flag = myPara.Flag;
        LoadImage(myPara.LoadImageSrc());
        SetColor();
    }

}
