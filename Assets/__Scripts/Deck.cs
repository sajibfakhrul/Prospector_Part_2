using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(JsonParseDeck))]

public class Deck : MonoBehaviour
{

    [Header("Inscribed")]
    public CardSpritesSO cardSprites;
    public GameObject prefabCard;
    public GameObject prefabSprite;
    public bool startFaceUp = true;

    [Header("Dynamic")]
    public Transform deckAnchor;
    public List<Card> cards;

    private JsonParseDeck jsonDeck;

    static public GameObject SPRITE_PREFAB {  get; private set; }


    // Start is called before the first frame update
    
    /*
    void Start()
    {
        InitDeck();
        Shuffle(ref cards);


    }
    */


    public void InitDeck()
    {
        SPRITE_PREFAB = prefabSprite;
        cardSprites.Init();
        jsonDeck = GetComponent<JsonParseDeck>();

        if(GameObject.Find("_Deck") == null)
        {
            GameObject anchorGO = new GameObject(" _Deck");
            deckAnchor = anchorGO.transform;
        }
        MakeCards();
    }

    void MakeCards(){
        cards = new List<Card>();
        Card c;

        string suits = "CDHS";
        for (int i = 0; i < 4; i++) {
            for (int j = 1; j <= 13; j++) {
                c = MakeCard(suits[i], j);
                cards.Add(c);

                c.transform.position =
                    new Vector3((j - 7) * 3, (i - 1.5f) * 4, 0);
            
            
            }
        
        }

    }

    Card MakeCard(char suit, int rank) {

        GameObject go = Instantiate<GameObject>(prefabCard, deckAnchor);

        Card card = go.GetComponent<Card>();    
        card.Init(suit, rank, startFaceUp);
        return card;

    }
    /// <summary>
    ///   Shuffle a List(Card) and return the result to the original list
    /// </summary>
    /// <param name="refCards"></param>


    static public void Shuffle(ref List<Card> refCards)
    {                     // 1
        // Create a temporary List to hold the new shuffle order
        List<Card> tCards = new List<Card>();
        int ndx; // This will hold the index of the card to be moved
        tCards = new List<Card>(); // Initialize the temporary List
        // Repeat as long as there are cards in the original List
        while (refCards.Count > 0)
        {
            // Pick the index of a random card
            ndx = Random.Range(0, refCards.Count);
            // Add that card to the temporary List
            tCards.Add(refCards[ndx]);
            // And remove that card from the original List
            refCards.RemoveAt(ndx);
        }
        // Replace the original List with the temporary List
        refCards = tCards;
        // Because  refCards is a reference variable, the original that was
        //   passed in is changed as well.
    }


}
