using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LabManagement : MonoBehaviour
{

    private static LabManagement instance=null;

    protected int maxLabCount; //max num can be shown in UI
    public int page;
    protected static int labPerPage = 6; //per lab for each page

    protected LabButton[] labHolder = new LabButton[labPerPage]; //object holder

    public List<LabParameter> labPara = new List<LabParameter>();

    public static LabManagement Instance
	{
        get { return instance; }
    }
    
    void Awake()
    {
        InitLab();
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }else 
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);//使对象目标在加载新场景时不被自动销毁。

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLabFlag(int labNum)
    {
        //print("set labnum: "+labNum);
        labPara[labNum].Flag=1;
    }

    public void ClearLabFlag(int labNum)
    {
        //print("clear labnum: "+labNum);
        labPara[labNum].Flag=0;
    }

    public void PageChange(bool pageup)
    {
        if(pageup==true && page < maxLabCount/labPerPage-1)
        {
            page++;
        }else if (pageup!=true && page>0)
        {
            page--;
        }else
        {
            //do nothing
        }
        InitLab(labPara,page);

    }

    private void ClearAllLabButton()
    {
        for(int i =0;i<labPara.Count;i++)
        {
            ClearLabFlag(i);
        }
    }


    public float[] GetResult()
    {
        
        float[] result = new float[]{0,0,0,0,0,0,0};
        LabParameter[] maxMinValue =new LabParameter[2];
        maxMinValue[0]=new LabParameter();
        maxMinValue[1]=new LabParameter();
        int selectLab=0;
        for(int i =0;i<labPara.Count;i++)
        { 
            if(labPara[i].Flag==1)
            {            
                selectLab++;
                result[0]+=labPara[i].Temperature;
                result[1]+=labPara[i].Humidity;
                result[2]+=labPara[i].FoodChain;
                result[3]+=labPara[i].Height;
                result[4]+=labPara[i].Cleanness;
                result[5]+=labPara[i].Risk;
                result[6]+=labPara[i].Breadth;
            }
        }

        GetMaxMinValue(labPara,maxMinValue,selectLab);
        //trasmit to part parameter
        float[] part={0,0,0,0,0};
        /*
        part[0]=(result[2]-maxMinValue[1].FoodChain)/(maxMinValue[0].FoodChain-maxMinValue[1].FoodChain)+
            (result[5]-maxMinValue[1].Risk)/(maxMinValue[0].Risk-maxMinValue[1].Risk);
        part[0]=part[0]/2;
        */
        part[0]=(result[2]-maxMinValue[1].FoodChain)/(maxMinValue[0].FoodChain-maxMinValue[1].FoodChain);
        part[1]=(result[0]-maxMinValue[1].Temperature)/(maxMinValue[0].Temperature-maxMinValue[1].Temperature)+
            (result[1]-maxMinValue[1].Humidity)/(maxMinValue[0].Humidity-maxMinValue[1].Humidity)+
            (result[6]-maxMinValue[1].Breadth)/(maxMinValue[0].Breadth-maxMinValue[1].Breadth);
        part[1]=part[1]/3;
        part[2]=(result[1]-maxMinValue[1].Humidity)/(maxMinValue[0].Humidity-maxMinValue[1].Humidity)+
            (result[3]-maxMinValue[1].Height)/(maxMinValue[0].Height-maxMinValue[1].Height)+
            (result[5]-maxMinValue[1].Risk)/(maxMinValue[0].Risk-maxMinValue[1].Risk);
        part[2]=part[2]/3;
        part[3]=(result[2]-maxMinValue[1].FoodChain)/(maxMinValue[0].FoodChain-maxMinValue[1].FoodChain)+
            (result[3]-maxMinValue[1].Height)/(maxMinValue[0].Height-maxMinValue[1].Height)+
            (result[4]-maxMinValue[1].Cleanness)/(maxMinValue[0].Cleanness-maxMinValue[1].Cleanness);
        part[3]=part[3]/3;
        part[4]=(result[0]-maxMinValue[1].Temperature)/(maxMinValue[0].Temperature-maxMinValue[1].Temperature)+
            (result[4]-maxMinValue[1].Cleanness)/(maxMinValue[0].Cleanness-maxMinValue[1].Cleanness)+
            (result[6]-maxMinValue[1].Breadth)/(maxMinValue[0].Breadth-maxMinValue[1].Breadth);
        part[4]=part[4]/3;
        //if selected labs are over 3, add random lab
        if(selectLab>3)
        {
            float[] rdPara = new float[5];
            GetLabPara(LABNAME.random,rdPara);
            part[0]+=rdPara[0];
            part[1]+=rdPara[1];
            part[2]+=rdPara[2];
            part[3]+=rdPara[3];
            part[4]+=rdPara[4];
        }
        
        //print("parts is :"+part[0]+" "+part[1]+" "+part[2]+" "+part[3]+" "+part[4]);
        
        ClearAllLabButton();
        return part;
        
    }
    
    public void GetMaxMinValue(List<LabParameter> labPara,LabParameter[] outputList,int selectedLabNum)
    {
        //calculate maxvalue by selectedLabNum valueList[0] is max value;valueList[1] is min value;
            List<int> temperatureList=new List<int>();
            List<int> humidityList=new List<int>();
            List<int> foodChainList=new List<int>();
            List<int> heightList=new List<int>();
            List<int> cleannessList=new List<int>();
            List<int> riskList=new List<int>();
            List<int> breadthList=new List<int>();
            //store the max/min value
            for(int i =0;i<labPara.Count;i++)
            {
                temperatureList.Add(labPara[i].Temperature);
                humidityList.Add(labPara[i].Humidity);
                foodChainList.Add(labPara[i].FoodChain);
                heightList.Add(labPara[i].Height);
                cleannessList.Add(labPara[i].Cleanness);
                riskList.Add(labPara[i].Risk);
                breadthList.Add(labPara[i].Breadth);
            }
            temperatureList.Sort();
            humidityList.Sort();
            foodChainList.Sort();
            heightList.Sort();
            cleannessList.Sort();
            riskList.Sort();
            breadthList.Sort();
            for(int i =0;i<selectedLabNum;i++)
            {
                //min value
                outputList[1].Temperature+=temperatureList[i];
                outputList[1].Humidity+=humidityList[i];
                outputList[1].FoodChain+=foodChainList[i];
                outputList[1].Height+=heightList[i];
                outputList[1].Cleanness+=cleannessList[i];
                outputList[1].Risk+=riskList[i];
                outputList[1].Breadth+=breadthList[i];
                print("min value is : "+outputList[1].Temperature+","+outputList[1].Humidity+","+outputList[1].FoodChain+","
                    +outputList[1].Height+","+outputList[1].Cleanness+","+outputList[1].Risk+","+outputList[1].Breadth);
                //max value
                outputList[0].Temperature+=temperatureList[temperatureList.Count-1-i];
                outputList[0].Humidity+=humidityList[humidityList.Count-1-i];
                outputList[0].FoodChain+=foodChainList[foodChainList.Count-1-i];
                outputList[0].Height+=heightList[heightList.Count-1-i];
                outputList[0].Cleanness+=cleannessList[cleannessList.Count-1-i];
                outputList[0].Risk+=riskList[riskList.Count-1-i];
                outputList[0].Breadth+=breadthList[breadthList.Count-1-i];
                print("max value is : "+outputList[0].Temperature+","+outputList[0].Humidity+","+outputList[0].FoodChain+","
                    +outputList[0].Height+","+outputList[0].Cleanness+","+outputList[0].Risk+","+outputList[0].Breadth);

            }


    }


    

    void InitLab(List<LabParameter> labPara,int page)
    {

        InitLabHolder();

        for(int i =0;i<labPerPage;i++)
        {
            if((i+page*labPerPage) < labPara.Count)
            {
                labHolder[i].LoadButtonResource(labPara[i+page*labPerPage]);
            }else
            {
                labHolder[i].LoadButtonResource(new LabParameter());
            }
        }
    }

    public void RegLabHolder(int num,LabButton labButton)
    {
        labHolder[num]=labButton;
    }

    public void InitLabHolder()
    {
        if(labHolder[0] == null || labHolder[1] == null || labHolder[2] == null || labHolder[3] == null || 
        labHolder[4] == null || labHolder[5] == null )
        {
            labHolder[0] =GameObject.Find("lab0").GetComponent<LabButton>();
            labHolder[1] =GameObject.Find("lab1").GetComponent<LabButton>();
            labHolder[2] =GameObject.Find("lab2").GetComponent<LabButton>();
            labHolder[3] =GameObject.Find("lab3").GetComponent<LabButton>();
            labHolder[4] =GameObject.Find("lab4").GetComponent<LabButton>();
            labHolder[5] =GameObject.Find("lab5").GetComponent<LabButton>();
        }
        
    }

    public void InitLab()
    {

        maxLabCount=((int)Math.Ceiling((float)labPara.Count/labPerPage) )*labPerPage;
        
        for(int i =0;i<labPara.Count;i++)
        {
            labPara[i].LabNum=i;
        }
        ClearAllLabButton();

        int page =0;

        InitLabHolder();

        for(int i =0;i<labPerPage;i++)
        {
            if((i+page*labPerPage) < labPara.Count)
            {
                labHolder[i].LoadButtonResource(labPara[i+page*labPerPage]);
            }else
            {
                labHolder[i].LoadButtonResource(new LabParameter());
            }
        }
    }


    public void GetLabPara(LABNAME labName,float[] para )
    {
        
        switch(labName)
        {
            case LABNAME.random:
                System.Random rd = new System.Random();
                para[0]=(float)(rd.NextDouble()-0.5f);
                para[1]=(float)(rd.NextDouble()-0.5f);
                para[2]=(float)rd.NextDouble()-0.5f;
                para[3]=(float)rd.NextDouble()-0.5f;
                para[4]=(float)rd.NextDouble()-0.5f;
                break;
        }
    }
}
