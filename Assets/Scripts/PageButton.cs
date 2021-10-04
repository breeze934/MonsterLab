using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButton : BaseButton
{
    public bool isPageUp;
    private LabManagement _labManagement;
    // Start is called before the first frame update
    void Start()
    {
        InitImage();
        _labManagement=GameObject.Find("LabManagement").GetComponent<LabManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(_labManagement == null)
        {
            _labManagement=GameObject.Find("LabManagement").GetComponent<LabManagement>();
        }else
        {
            //do nothing
        }
        _labManagement.PageChange(isPageUp);
    }
}
