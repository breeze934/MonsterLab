using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    int btnCnt = 0;

    GameObject lab1;
    GameObject lab2;
    GameObject lab3;
    GameObject lab4;
    GameObject lab5;
    GameObject lab6;
    GameObject quest;
    GameObject questImage;
    GameObject img_popupImage;
    GameObject txt_popupText;
    GameObject btn_ok;
    GameObject btn_cancel;

    bool btnChg1 = true;
    bool btnChg2 = true;
    bool btnChg3 = true;
    bool btnChg4 = true;
    bool btnChg5 = true;
    bool btnChg6 = true;
    bool questg = false;

    public int temperature; //�¶�
    public int height;      //�߶�
    public int pressure;    //ѹǿ
    public int humidity;    //ʪ��
    public int luminance;   //����


    //   int[] btno = new int[3];

    static readonly Color btnWhiteCol = Color.white;
    static readonly Color btnGreyCol = Color.grey;

    public void onClick_lab1()
    {
        int t_btnCnt;
        int t_humidity;  //ʪ��
        int t_luminance; //����

        t_btnCnt = btnCnt;
        t_humidity = humidity;
        t_luminance = luminance;

        btnChg1 = !btnChg1;
        if (btnChg1)
        {
            lab1.GetComponent<Image>().color = Color.white;
            t_btnCnt--;
            t_humidity += 2;
            t_luminance += 1;
        }
        else
        {
            lab1.GetComponent<Image>().color = Color.grey;
            t_btnCnt++;
            t_humidity -= 2;
            t_luminance -= 1;
/*            for (int i = 0; i < 3; i++)
            {
                if (btno[i] == 0)
                {
                    btno[i] = 1;
                }
            }*/
        }
        btnCnt = t_btnCnt;
        humidity = t_humidity;
        luminance = t_luminance;
    }

    public void onClick_lab2()
    {
        int t_btnCnt;
        int t_pressure; //ѹǿ
        int t_luminance; //����

        t_btnCnt = btnCnt;
        t_pressure = pressure;
        t_luminance = luminance;

        btnChg2 = !btnChg2;
        if (btnChg2)
        {
            lab2.GetComponent<Image>().color = Color.white;
            t_btnCnt--;
            t_pressure -= 3;
            t_luminance += 2;
        }
        else
        {
            lab2.GetComponent<Image>().color = Color.grey;
            t_btnCnt++;
            t_pressure += 3;
            t_luminance -= 2;
        }
        btnCnt = t_btnCnt;
        pressure = t_pressure;
        luminance = t_luminance;
    }

    public void onClick_lab3()
    {
        int t_btnCnt;
        int t_temperature; //�¶�
        int t_humidity;    //ʪ��
        int t_luminance;   //����

        t_btnCnt = btnCnt;
        t_temperature = temperature;
        t_humidity = humidity;
        t_luminance = luminance;

        btnChg3 = !btnChg3;
        if (btnChg3)
        {
            lab3.GetComponent<Image>().color = Color.white;
            t_btnCnt--;
            t_temperature += 2;
            t_humidity -= 2;
            t_luminance -= 1;
        }
        else
        {
            lab3.GetComponent<Image>().color = Color.grey;
            t_btnCnt++;
            t_temperature -= 2;
            t_humidity += 2;
            t_luminance += 1;
        }
        btnCnt = t_btnCnt;
        temperature = t_temperature;
        humidity = t_humidity;
        luminance = t_luminance;
    }

    public void onClick_lab4()
    {
        int t_btnCnt;
        int t_height;   //�߶�
        int t_pressure; //ѹǿ
        int t_luminance;//����

        t_btnCnt = btnCnt;
        t_height = height;
        t_pressure = pressure;
        t_luminance = luminance;

        btnChg4 = !btnChg4;
        if (btnChg4)
        {
            lab4.GetComponent<Image>().color = Color.white;
            t_btnCnt--;
            t_height -= 4;
            t_pressure += 2;
            t_luminance -= 4;
        }
        else
        {
            lab4.GetComponent<Image>().color = Color.grey;
            t_btnCnt++;
            t_height += 4;
            t_pressure -= 2;
            t_luminance += 4;
        }
        btnCnt = t_btnCnt;
        height = t_height;
        pressure = t_pressure;
        luminance = t_luminance;
    }

    public void onClick_lab5()
    {
        int t_btnCnt;
        int t_humidity;    //ʪ��
        int t_height;      //�߶�
        int t_temperature; //�¶�

        t_btnCnt = btnCnt;
        t_humidity = humidity;
        t_height = height;
        t_temperature = temperature;

        btnChg5 = !btnChg5;
        if (btnChg5)
        {
            lab5.GetComponent<Image>().color = Color.white;
            t_btnCnt--;
            t_humidity -= 3;
            t_height += 2;
            t_temperature -= 1;
        }
        else
        {
            lab5.GetComponent<Image>().color = Color.grey;
            t_btnCnt++;
            t_humidity += 3;
            t_height -= 2;
            t_temperature += 1;
        }
        btnCnt = t_btnCnt;
        humidity = t_humidity;
        height = t_height;
        temperature = t_temperature;
    }

    public void onClick_lab6()
    {
        int t_btnCnt;
        int t_temperature; //�¶�
        int t_humidity;    //ʪ��
        int t_pressure;    //ѹǿ

        t_btnCnt = btnCnt;
        t_temperature = temperature;
        t_humidity = humidity;
        t_pressure = pressure;

        btnChg6 = !btnChg6;
        if (btnChg6)
        {
            lab6.GetComponent<Image>().color = Color.white;
            t_btnCnt--;
            t_humidity += 1;
            t_temperature -= 4;
            t_pressure -= 1;
        }
        else
        {
            lab6.GetComponent<Image>().color = Color.grey;
            t_btnCnt++;
            t_humidity -= 1;
            t_temperature += 4;
            t_pressure += 1;
        }
        btnCnt = t_btnCnt;
        temperature = t_temperature;
        humidity = t_humidity;
        pressure = t_pressure;
    }

    public void onClick_quest()
    {
        questg = !questg;
        if (questg)
        {
            questImage.SetActive(true);
        }
        else
        {
            questImage.SetActive(false);
        }
    }



    private void Awake()
    {
        lab1 = GameObject.Find("lab0");
        lab2 = GameObject.Find("lab1");
        lab3 = GameObject.Find("lab2");
        lab4 = GameObject.Find("lab3");
        lab5 = GameObject.Find("lab4");
        lab6 = GameObject.Find("lab5");
        quest = GameObject.Find("quest");
        questImage = GameObject.Find("questImage");
        img_popupImage = GameObject.Find("popupImage");
        txt_popupText = GameObject.Find("popupText");
        btn_ok = GameObject.Find("ok");
        btn_cancel = GameObject.Find("cancel");

        lab1.GetComponent<Image>().color = Color.white;
        lab2.GetComponent<Image>().color = Color.white;
        lab3.GetComponent<Image>().color = Color.white;
        lab4.GetComponent<Image>().color = Color.white;
        lab5.GetComponent<Image>().color = Color.white;
        lab6.GetComponent<Image>().color = Color.white;

        questImage.SetActive(false);
        img_popupImage.SetActive(false);
        txt_popupText.SetActive(false);
        btn_ok.SetActive(false);
        btn_cancel.SetActive(false);

        temperature = 0;
        height      = 0;
        pressure    = 0;
        humidity    = 0;
        luminance   = 0;

        /*        for (int i = 0; i < 3; i++)
                {
                    btno[i] = 0;
                }*/
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
            img_popupImage.SetActive(true);
            txt_popupText.SetActive(true);
            btn_ok.SetActive(true);
            btn_cancel.SetActive(true);
        }
        else if (btnCnt < 3)
        {
            img_popupImage.SetActive(false);
            txt_popupText.SetActive(false);
            btn_ok.SetActive(false);
            btn_cancel.SetActive(false);
        }
    }
}
