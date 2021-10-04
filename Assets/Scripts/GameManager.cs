using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    TaskManagement taskManagement;
    LabManagement labManagement;
    private int[] value = new int[4]{0,0,0,0}; 
    public Position[] parts;
    //string[] headName,bodyName,legName,wingName,tailName;
    string[][] name;
    //public Selectbutton button1,button2,button3,button4,button5,button6;
    // Start is called before the first frame update
    //Partern myPatern = this.GetComponent<Partern>();
    public Text head;
    public Text body;
    public Text hand;
    public Text tail;
    public Text foot;
    public Text Assessment;
    void Awake(){
        //DontDestroyOnLoad(transform.gameObject);
        name =new string[5][];
        //headName
        name[0]=new string[]{"fireflyhead","godpeoplehead","fishhead","sheephead","deerhead","robothead"};
        //bodyName
        name[1]=new string[]{"snowmanbody","fishbody","chocobody","sheepbody","godpeoplebody","robotbody"};
        //legName
        name[2]=new string[]{"buglegs","robotleg","ducklegs","eaglefoot","bearlegs","horselegs","empty"};
        //wingName
        name[3]=new string[]{"zhangyuhand","fishhands","godpeoplehands","deerhand","eaglehands","01hand","empty"};
        //tailName
        name[4]=new string[]{"fish2tail","fishtail","hooktail","monkeytail","scorpointail","hamertail","empty"};
    }
    void Start()
    {
        parts = new Position[5];
        parts[0] = GameObject.FindWithTag("Head").GetComponent<Position>();
        parts[1] = GameObject.FindWithTag("Body").GetComponent<Position>();
        parts[2] = GameObject.FindWithTag("Leg").GetComponent<Position>();
        parts[3] = GameObject.FindWithTag("Wing").GetComponent<Position>();
        parts[4] = GameObject.FindWithTag("Tail").GetComponent<Position>();
        Assessment =GameObject.Find("AssessmentText").GetComponent<Text>();
        taskManagement = GameObject.Find("TaskManagement").GetComponent<TaskManagement>();
        refreshPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //print("Head :"+Head.GetComponent<Transform>().position.x+","+Head.GetComponent<Transform>().position.y);
    }
    
    public int getValue(int n){
        int x;
        if(n<=3){
            x= value[n];
        }else{
            x= 0;
        }
        return x;
    }

    public void setValue(int m,int n){
        if(m<=3){
            value[m]=n;
        }else{
            //nothing
        }
    }

    public void refreshPosition()
    {
        //Head.setPosition(position[0]);
        //Leg.setPosition(position[1]);
        //Wing.setPosition(position[2]);
        //Tail.setPosition(position[3]);
        labManagement=GameObject.Find("LabManagement").GetComponent<LabManagement>();
        float[] k = new float[5];
        int[] bodyNo=new int[5];
        k=labManagement.GetResult();
        //print(k[0]);
        //print(k[1]);
        //print(k[2]);
        //print(k[3]);
        //print(k[4]);


        transResult(k,bodyNo);


        for (int i =0;i<5;i++)
        {
            parts[i].setPicture(name[i][bodyNo[i]]);
            //print(i+":"+name[i][bodyNo[i]]);
        }
    }

    private void transResult(float[] input,int[] output){
        /*
        output[0]=input[2]+input[5];
        output[1]=input[0]+input[1]+input[6];
        output[2]=input[1]+input[3]+input[5];
        output[3]=input[2]+input[3]+input[4];
        output[4]=input[0]+input[4]+input[6];
         */
       
        for(int i = 0 ;i<5;i++){
            //output[i]=(int)((output[i]+3)/3.0)*name[i].Length;
            float k = 1;
            while(input[i]>k/name[i].Length && k<name[i].Length){
                k++;
                if(k>100) break;
            }
            output[i]=(int)(k-1);
        }
        if(head != null && body!=null && foot!=null && hand!=null && tail!=null&& Assessment!=null)
        {
            if(taskManagement != null)
            {
                int hint=taskManagement.EstimateTask(output);
                Assessment.text = taskManagement.ShowComment(hint);
            }else
            {
                Assessment.text="hint is null";
            }
            head.text = taskManagement.showPartsComment(0,output[0]);
            body.text = taskManagement.showPartsComment(1,output[1]);
            foot.text = taskManagement.showPartsComment(2,output[2]);
            hand.text = taskManagement.showPartsComment(3,output[3]);
            tail.text = taskManagement.showPartsComment(4,output[4]);
        }

    }
}
