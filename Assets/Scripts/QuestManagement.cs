using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagement : MonoBehaviour
{
    int btnCnt = 0;
    static int questObjectNum =5;
    struct QuestObject{
        public GameObject gameobject;
        public int flag;
    }
    GameObject quest;
    GameObject btn_ok;
    GameObject btn_cancel;
    QuestObject[] questObject= new QuestObject[questObjectNum];
    private void Awake()
    {
        //questObject[0].gameobject = GameObject.Find("questButton");
        questObject[0].gameobject = GameObject.Find("questImage");
        questObject[1].gameobject = GameObject.Find("popupImage");
        questObject[2].gameobject = GameObject.Find("popupText");
        questObject[3].gameobject = GameObject.Find("okButton");
        questObject[4].gameobject  = GameObject.Find("cancelButton");
        InitQuestObject();
        

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (btnCnt >= 3)
        {

        }
        else if (btnCnt < 3)
        {

        }
    }

    public void SetQuestObject(int active,int num)
    {
        questObject[num].flag=active;
        if(active==1){
            questObject[num].gameobject.SetActive(true);
        }else{
            questObject[num].gameobject.SetActive(false);
        }
        

    }

    public void SetQuestObject(int num)
    {
        
        if(questObject[num].flag==0){
            questObject[num].gameobject.SetActive(true);
            questObject[num].flag=1;
        }else{
            questObject[num].gameobject.SetActive(false);
            questObject[num].flag=0;
        }
    }

    void InitQuestObject(){
        for (int i =0;i<questObjectNum;i++){
            if(questObject[i].gameobject !=null)
            {
                questObject[i].gameobject.SetActive(false);
                questObject[i].flag=0;
            }
        }
    }


}
