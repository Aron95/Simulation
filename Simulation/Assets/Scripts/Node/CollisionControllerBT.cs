using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class CollisionControllerBT : CollisionController
{
   public override bool isValidNode(nodeProperty otherNp){
    return otherNp.canGetBluetooth;
   }
}
