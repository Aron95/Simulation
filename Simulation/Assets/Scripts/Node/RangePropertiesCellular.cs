using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class RangePropertiesCellular : RangeProperties
{
    public GameObject messageDotType;
    public double energyUsage = 0;

    public override bool isValidNode(nodeProperty otherNp){
        return otherNp.canGetCellular;
    }

    public override GameObject getMessageDotType(){
        return messageDotType;
    }

    public override double getEnergyUsage(){
        return energyUsage;
    }
}
