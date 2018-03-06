using UnityEngine;
using UnityEditor;

public interface ISauvegardable
{
    void SaveState();
    void LoadState();
}