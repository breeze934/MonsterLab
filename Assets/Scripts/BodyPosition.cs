using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPosition : MonoBehaviour
{
    public Vector3 center,head,leg,wing,tail;
    // Start is called before the first frame update
    void Start()
    {
        head =new Vector3(0,1,0);
        leg = new Vector3(-2,1,0);
        wing=new Vector3(-3,3,0);
        tail=new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getHeadPosition(){
        return head;
    }

    public Vector3 getLegPosition(){
        return leg;
    }

    public Vector3 getWingPosition(){
        return wing;
    }

    public Vector3 getTailPosition(){
        return tail;
    }


}
