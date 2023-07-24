using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//a scriptable object that stores information for every in-game 'fish' object
[CreateAssetMenu]
public class FishSO : ScriptableObject
{
    //public string name;
    public Sprite photo;
    public string description;
    public int weight;
}
