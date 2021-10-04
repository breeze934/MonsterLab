using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioContoller : MonoBehaviour
{
    Scrollbar scrollbar;
    private audio audiomanagement;
    // Start is called before the first frame update
    void Start()
    {
        scrollbar=this.GetComponent<Scrollbar>();
        audiomanagement=GameObject.FindWithTag("AudioManagement").GetComponent<audio>();
        scrollbar.value=audiomanagement.GetMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {
        audiomanagement.SetMusicVolume(scrollbar.value);
    }
}
