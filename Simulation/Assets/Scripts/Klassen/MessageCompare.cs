using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCompare : IEqualityComparer<messageContent>{
    bool IEqualityComparer<messageContent>.Equals(messageContent x, messageContent y)
    {
       return x.id == y.id;
    }

    int IEqualityComparer<messageContent>.GetHashCode(messageContent obj)
    {
        return obj.id;
    }

 
}
