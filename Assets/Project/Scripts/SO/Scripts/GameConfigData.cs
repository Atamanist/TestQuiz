using UnityEngine;

[CreateAssetMenu(fileName = "GameConfigData", menuName = "ScriptableObjects/GameConfigData", order = 1)]
public class GameConfigData : ScriptableObject
{
    public string Path;
    public int Lenght;
    public int Lives;
    public string Letters;
}
