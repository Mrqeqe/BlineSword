using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoName : MonoBehaviour
{
    private static string _start = "start";
    public static string Start { get { return _start; }set { _start = value; } }
    private static string _end = "end";
   public static string End { get { return _end ; } set { _end = value; } }
}
