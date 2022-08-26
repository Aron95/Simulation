using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class CollisionControllerCellular : CollisionController
{
    public override bool isValidNode(nodeProperty otherNp){
    return otherNp.canGetCellular;
   }
}
