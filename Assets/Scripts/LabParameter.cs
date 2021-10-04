using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LabParameter
{
    
    private int _labFlag;
    protected int _labNum;
    public string labName;
    public int _temperature,_humidity,_foodChain,_height,_cleanness,_risk,_breadth;
    public Sprite backImage;
    public LabParameter()
    {
        this._labFlag = 0;
        this._labNum = -1;
        this.labName="???";
        this._temperature =this._humidity=this._foodChain=this._height=this._cleanness=this._risk=this._breadth=0;
    }
    
    public int Flag
    {
        get { return _labFlag;}
        set {_labFlag=value;}
    }
    
    public int Temperature
    {
        get { return _temperature;}
        set {  _temperature=value; }
    }

    public int Humidity
    {
        get { return _humidity; }
        set {  _humidity=value; }
    }

    public int FoodChain
    {
        get { return _foodChain; }
        set {  _foodChain=value; }
    }

    public int Height
    {
        get { return _height; }
        set { _height=value; }
    }

    public int Cleanness
    {
        get { return _cleanness; }
        set {  this._cleanness=value; }
    }

    public int Risk
    {
        get { return _risk; }
        set { _risk=value; }
    }

    public int Breadth
    {
        get { return _breadth; }
        set { _breadth = value; }
    }

    public int LabNum
    {
        get {return _labNum;}
        set {_labNum = value;}
    }

    public Sprite LoadImageSrc()
    {
        if(this.backImage == null)
        {
            backImage=Resources.Load<Sprite>("ButtonPicture/default");
        }else
        {
            //nothing
        }
        return backImage;
    }
}

public enum LABNAME 
{
    random,
    empty
}
