using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    public Image image;
    private Sprite sprite;
    int n;
    


    // Start is called before the first frame update
    void Start()
    {
        n = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (n == 0)
        {
            sprite = Resources.Load<Sprite>("client_A");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        if (n == 1)
        {
            sprite = Resources.Load<Sprite>("client_B");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        if (n == 2)
        {
            sprite = Resources.Load<Sprite>("client_C");
            image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}
