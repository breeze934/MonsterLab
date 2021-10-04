using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : BaseButton
{
    LabManagement labManagement;
    // Start is called before the first frame update
    void Start()
    {
        InitImage();
        labManagement=GameObject.Find("LabManagement").GetComponent<LabManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick(string scenceName)
    {
        Destroy(labManagement);
        ChangeScence(scenceName);

    }
}
