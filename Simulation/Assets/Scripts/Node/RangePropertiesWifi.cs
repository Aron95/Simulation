using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class RangePropertiesWifi : RangeProperties
{
    public GameObject messageDotType;
    public double energyUsage = 1;

    public override bool isValidNode(nodeProperty otherNp){
        return otherNp.canGetWifi;
    }

    public override GameObject getMessageDotType(){
        return messageDotType;
    }

    public override double getEnergyUsage(){
        return energyUsage;
    }
}
