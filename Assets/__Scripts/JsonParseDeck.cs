using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
  //  This class stores information about each decorator or pip from DeckXML
   public class JsonPip{
    public string type = "pip"; //  "pip". "letter"
    public Vector3 loc;  // The location of the Sprite on the Card
    public bool flip = false;  // Whether to flip the Sprite vertically
    public float scale = 1;    // The scale of the Sprite

    }

// This class stores information for each rank of card
[System.Serializable]
    public class JsonCard{
        public int rank; // The rank (1-13) of this card
        public string face; // Sprite to use for each face card
    
        public List<JsonPip> pips = new List<JsonPip>();  // Pips used
    
    }

// This class contains information for each rank of card
[System.Serializable]
    public class JsonDeck{
        public List<JsonPip> decorators = new List<JsonPip>();
        public List<JsonCard> cards = new List<JsonCard>();
    

    }




public class JsonParseDeck : MonoBehaviour
{

    private static JsonParseDeck S { get; set; } // Another automatic property
    [Header("Inscribed")]
    public TextAsset jsonDeckFile; // Reference to the JSON_DECK text file

    [Header("Dynamic")]
    public JsonDeck deck;

     void Awake()
    {
        if (S != null){
            Debug.LogError("JsonParseDeck.S can't be set a 2nd time!");
            return;

        }
        S = this;
        deck = JsonUtility.FromJson<JsonDeck>(jsonDeckFile.text);
    }

    ///<summary>
    /// Returns the decorator layout information for all cards
    /// </summary
    
    static public List<JsonPip> DECORATORS
    {
        get  { return S.deck.decorators; }
    }

    ///<summary>
    ///  Returns the JsonCard matching the rank passed in.
    ///  Note: The rank should be 1(Ace) - 13 (King)
    /// </summary>

    static public JsonCard GET_CARD_DEF(int rank){

        if ((rank < 1) || (rank > S.deck.cards.Count)) {
            Debug.LogWarning("Illegal rank argument: " + rank);
            return null;
        
        }
        return S.deck.cards[rank -1];

    }



}
