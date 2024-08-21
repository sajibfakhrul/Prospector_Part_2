using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores information about the layout of the Prospector mine.
/// </summary>

[System.Serializable]
public class JsonLayout
{
    public Vector2 multiplier;
    public List<JsonLayoutSlot> slots;
    public JsonLayoutPile drawPile, discardPile;
}

/// <summary>
/// Stores information for each slot in the layout
/// Implements Unity's ISerializationCallbackReceiver Interface.
/// </summary>

[System.Serializable]
public class JsonLayoutSlot : ISerializationCallbackReceiver
{
    public int id;
    public int x;
    public int y;
    public bool faceUp;
    public string layer;
    public string hiddenByString;

    [System.NonSerialized]
    public List<int> hidddenBy;


    ///<summary>
    /// Pulls data from hiddenByString and places it into the hiddenBy List
    /// </summary>
   
    public void OnAfterDeserialize()
    {
        hidddenBy = new List<int>();
        if (hiddenByString.Length == 0) return;

        string[] bits = hiddenByString.Split(',');
        for (int i = 0; i < bits.Length; i++)
        {
            hidddenBy.Add(int.Parse(bits[i]));
        }
    }

    /// <summary>
    ///  Required by ISerializationCallbackReceiver, but empty in this class
    /// </summary>
    public void OnBeforeSerialize()
    {

    }

    ///<summary>
    /// Store information for the draw and discard piles
    /// </summary>

}
[System.Serializable]
public class JsonLayoutPile
{
    public int x, y;
    public string layer;
    public float xStagger; // xStagger fans cards to the side for the draw pile
}

public class JsonParseLayout : MonoBehaviour
{
   public static JsonParseLayout S { get; private set; }

    [Header("Inscribed")]
    public TextAsset jsonLayoutFile;

    [Header("Dynamic")]

    public JsonLayout layout;


     void Awake()
    {
        layout= JsonUtility.FromJson<JsonLayout>(jsonLayoutFile.text);
        S = this;
    }

}
