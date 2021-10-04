using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : BaseButton
{
    QuestManagement questManagement;
    // Start is called before the first frame update
    void Start()
    {
        questManagement=GameObject.Find("QuestManagement").GetComponent<QuestManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(string scenceName){
        questManagement.SetQuestObject(1,1);
        questManagement.SetQuestObject(1,2);
        questManagement.SetQuestObject(1,3);
        questManagement.SetQuestObject(1,4);
    }

    public void CancelClick()
    {
        questManagement.SetQuestObject(0,1);
        questManagement.SetQuestObject(0,2);
        questManagement.SetQuestObject(0,3);
        questManagement.SetQuestObject(0,4);
    }
}
