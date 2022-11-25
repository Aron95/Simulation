using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class RangePropertiesBT : RangeProperties
{
    public GameObject messageDotType;
    public double energyUsage = 0.8;

    public override bool isValidNode(nodeProperty otherNp) {
        return otherNp.canGetBluetooth;
    }

    public override GameObject getMessageDotType() {
        return messageDotType;
    }

    public override double getEnergyUsage(){
        return energyUsage;
    }
}
