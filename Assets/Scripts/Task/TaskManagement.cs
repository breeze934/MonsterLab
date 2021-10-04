using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskManagement : MonoBehaviour
{
    string comment ;
    private static TaskManagement instance=null;
    public List<TaskTag> taskCards;
    public List<Person> customs;
    public List<Parts> headParts;
    public List<Parts> bodyParts;
    public List<Parts> legParts;
    public List<Parts> handParts;
    public List<Parts> tailParts;
    Text[] taskBar;
    System.Random rd;
    string[] headTask ={};
    string[] BodyTask = {};
    string[] HandTask = {};
    string[] LegTask  = {};
    string[] TailTask = {};
    //string[] TaskDetail =  {"弱小，可爱，温顺","傻，不易逃跑","是植物","生存环境和水有关的生物，如海底，池塘，河流","食草类动物","杂食性动物","有感情，会陪伴","可自己生存，甚至协助人类工作","生存环境很冷，如高山，南北极","生存环境湿润，如沼泽，水中",
    //    "生存环境开阔，如草原，平原，大海","生存环境温度低，如水中 ","生存环境温度高，如火山，沙漠等","粘稠的身体","温度湿度等都适中的地点，如城市","好吃","生活环境干燥，如沙漠","强","生活在海底","生活条件危险，通常自己本身也是危险的存在",
    //       "生活在高出","脏","生活在空中，可以飞","高等级生物，强大，聪明，凶狠"};
    string[] TaskDetail ={"Easy to be preyed,low intelligence","Plant, easy to be preyed","under water, easy to be preyed,low intelligence","herbivores, medium intelligence","omnivorous animal,medium intelligence",
        "Predator,High intelligence"};
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }else 
        {
            instance = this;
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
    
    
    void Start()
    {
        InitTask();
        InitPerson();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ShowComment(int hint)
    {
        string comment;
        if(hint <2)
        {
            comment = "not bad!";
        }else if (hint <3)
        {
            comment = "good job!";
        }else 
        {
            comment = " pretty good!";
        }
        return comment;
    }

    public string showPartsComment(int partsNum,int no)
    {
        
        switch(partsNum)
        {
            case 0:
                comment =headParts[no].detail;
                break;
            case 1:
                comment =bodyParts[no].detail;
                break;
            case 2:
                comment =legParts[no].detail;
                break;
            case 3:
                comment =handParts[no].detail;
                break;
            case 4:
                comment =tailParts[no].detail;
                break;
        }
        return comment;
    }

    void InitTask()
    {
        taskBar = new Text[6];

        taskBar[0] = GameObject.Find("TaskBar0").GetComponent<Text>();
        taskBar[1] = GameObject.Find("TaskBar1").GetComponent<Text>();
        taskBar[2] = GameObject.Find("TaskBar2").GetComponent<Text>();
        taskBar[3] = GameObject.Find("TaskBar3").GetComponent<Text>();
        taskBar[4] = GameObject.Find("TaskBar4").GetComponent<Text>();
        taskBar[5] = GameObject.Find("Personality").GetComponent<Text>();
        System.Random rd = new System.Random();
        //int[5][2] selectedTask=new int();
        //selectedTask[0] = rd.Next(headTask.Length);
 
    }

    public int EstimateTask(int[] selectedParts)
    {
        List<Tag> tmpTag = new List<Tag>();
        for(int i = 0;i<customs.Count;i++)
        {
            if(customs[i].Flag == 1)
            {
                for(int k =0;k<customs[i].TagCount;k++)
                {
                    tmpTag.Add(customs[i].tag[k]);
                }
            }
        }
        int hint = 0;
        for(int i =0;i<tmpTag.Count;i++)
        {
            for(int k =0;k<5;k++)
            {
                for(int j = 0;j<headParts[selectedParts[0]].partsTag.Count;j++)
                {
                    if(headParts[selectedParts[0]].partsTag[j]==tmpTag[i])
                    {
                        hint++;
                    }
                }
            }
        }
        return hint;
        
    }

    void InitPerson()
    {
        rd = new System.Random();
        int k = rd.Next(customs.Count);
        Person tmp = customs[k];
        tmp.Flag = 1;
        taskBar[5].text="Name: "+tmp.Name+"  Sex: "+tmp.Sex+"  Age: "+tmp.Age;
        for(int i =0;i<tmp.TagCount && i<5;i++)
        {
            taskBar[i].text=TaskDetail[(int)tmp.tag[i]];
        }
    }



    [System.Serializable]
    public class TaskTag
    {
        protected int _flag;
        public Tag tagNum;
        public string tag;
        public string detail;
        public int Flag
        {
            set {_flag = value;}
            get{return _flag;}
        }
    }

    [System.Serializable]
    public class Person
    {
        protected int _flag;
        public int PerNum;
        public string Name;
        public string Sex;
        public string Age;
        public List<Tag> tag;
        public int Flag
        {
            set {_flag = value;}
            get{return _flag;}
        }
        public int TagCount
        {
            get{return tag.Count;}
        }
    }

    [System.Serializable]
    public class Parts
    {
        protected int _flag;
        public string name;
        public string detail;
        public int partsNum;
        public int PartsNo;
        public List<Tag> partsTag;
    }


    public enum Tag
    {
        tag0 = 0,
        tag1,
        tag2,
        tag3,
        tag4,
        tag5,
        tag6,
        tag7,
        tag8,
        tag9,
        tag10,
        tag11,
        tag12,
        tag13,
        tag14,
        tag15,
        tag16,
        tag17,
        tag18,
        tag19,
        tag20,
        tag21,
        tag22,
        tag23
        
    }

    public enum PartNum
    {
        Head,
        Body,
        Leg,
        Hand,
        Tail
    }

}

