using UnityEngine;
using UnityEditor;

public abstract class Conditions :ScriptableObject
{
    public abstract bool verify();
}