using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class RomeoData : ScriptableObject
{
    [SerializeField]
    public LevelLoader.Levels previousLocation = LevelLoader.Levels.MainMenu;

   
}
