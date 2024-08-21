using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is an enum, which defines a type of variable that only has a few
// possible named values. The CardState variable type has one of four values:
// drawpile, tableau, target, & discard
public enum eCardState
{
    drawpile,
    mine,
    target,
    discard
}

public class CardProspector : Card
{
    // Make CardProspector extends Card
    [Header("Dynamic: CardProspector")]
    // This is how you use the enum CardState
    public eCardState state = eCardState.drawpile;

    // The hiddenBy list stores which other cards will keep this one face down
    public List<CardProspector> hiddenBy = new List<CardProspector>();
    // The LayoutID matches this card to the tableau JSON  if it's a tableau  card
    public int layoutID;
    // The JsonLayoutSlot class stores information pulled in from the JSON_Layout
    public JsonLayoutSlot layoutSlot;


    /// <summary>
    /// Informs the Prospector class that this card has been clicked
    /// </summary>
    
    override public void OnMouseUpAsButton()
    {

        // Uncomment the next line to call the base class version of this method 
       // base.OnMouseUpAsButton();
        // Call the CardClicked method on the Prospector singleton
        Prospector.CARD_CLICKED(this);
        
       
    }
}
