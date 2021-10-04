using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class okButton : BaseButton
{
    LabManagement myLab;
    // Start is called before the first frame update
    void Start()
    {
        myLab = GameObject.Find("LabManagement").GetComponent<LabManagement>();
        this.isEnable=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(string scenceName)
    {
        //myLab.GetResult();
        ChangeScence(scenceName);
    }

    
}
