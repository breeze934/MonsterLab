using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle=this.GetComponent<Toggle>();
        toggle.isOn=false;
    }

    // Update is called once per frame
    void Update()
    {
        Screen.fullScreen=toggle.isOn;
    }
}
