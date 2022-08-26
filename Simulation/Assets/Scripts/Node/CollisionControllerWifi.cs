using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class CollisionControllerWifi : CollisionController
{
   public override bool isValidNode(nodeProperty otherNp){
    return otherNp.canGetWifi;
   }
}
