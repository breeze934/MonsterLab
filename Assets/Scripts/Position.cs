using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    Vector3 myPosition; 
    // Start is called before the first frame update
    void Start()
    {
        myPosition= this.transform.position; 
        //transform = GameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.position = myPosition;
    }

    public void setPosition(Vector3 newPosition){
        myPosition = newPosition;
        
    }
    
    public void setPicture(string name){
        //print(this.transform.childCount);
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child = this.transform.GetChild(i).gameObject;
            if(string.Compare(child.name,name)!=0){
                child.SetActive(false);
                //print("f");
            }else{
                child.SetActive(true);
                //print("t");
            }
        }
    }
   
}
