using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButton : BaseButton
{
    //public string scenceName;
    QuestManagement questMangement;
    // Start is called before the first frame update
    void Start()
    {
        questMangement=GameObject.FindWithTag("QuestManagement").GetComponent<QuestManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(){
        //ChangeScence(scenceName);
        if(questMangement!=null){
            questMangement.SetQuestObject(0);
        }else{
            print("questManagement no found!!");
        }
        
    }


}
