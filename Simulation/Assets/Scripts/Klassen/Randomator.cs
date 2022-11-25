using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomator {

    private static System.Random _rnd;
    public static System.Random rnd { get{ return _rnd != null ? _rnd : (_rnd = new System.Random()); } }

    public static int Next(){
        return rnd.Next();
    }
}
