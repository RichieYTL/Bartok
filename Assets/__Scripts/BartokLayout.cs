using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartokLayout : MonoBehaviour {

	public PT_XMLReader xmlr; //Just like Deck
	public PT_XMLHashTable  xml; //This variable is for faster xml access
	public Vector2 multiplier; //Sets the spacing for the tableau
	//SlotDef references
	public List<SlotDef> slotDefs; //The SlotDef hands
	public SlotDef drawPile;
	public SlotDef discardPile;
	public SlotDef target;

	//This function is called to read in the LayoutXML.xml file
	public void ReadLayout(string xmlText){
		xmlr = new PT_XMLReader ();
		xmlr.Parse (xmlText); //The XML is parsed
		xml = xmlr.xml["xml"][0]; //And XML is set as a shortcut to the XML;

		//Read in the multiplier which sets card spacing
		multiplier.x = float.Parse(xml["multiplier"][0].att("x"));
		multiplier.y = float.Parse(xml["multiplier"][0].att("y"));

		//Read in the slots
		SlotDef tSD;
		//slotsX is used as a shortcut to all the <slot>s
		PT_XMLHashList slotsX = xml["slots"];

		for (int i = 0; i < slotsX.Count; i++) {
			tSD = new SlotDef (); //Create a new SlotDef instance
			if (slotsX [i].HasAtt ("type")) {
				//If this <slot> has a type attribute parse it
				tSD.type = slotsX [i].att ("type");
			} else {
				//If not, set its type to "slot"
				tSD.type = "slot";
			}

			//Various attributes are parsed into numerical values
			tSD.x = float.Parse(slotsX[i].att("x"));
			tSD.y = float.Parse(slotsX[i].att("y"));
			tSD.pos = new Vector3 (tSD.x * multiplier.x, tSD * multiplier.y, 0);

			//Sorting Layers
			tSD.layerID = int.Parse(slotsX[i].att("layer"));
			//In this game, the Sorting Layers are named 1, 2, 3, ...through 10
			//This converts the number of the layerID into a text layerName
			tSD.layerName = tSD.layerID.ToString();
			//The layers are used to make sure that the correct cards are
			// on top of the others. In Unity2D, all of our assets are
			// effectively at the same Z depth, so sorting layers are used
			// to differentiate between them.

			//pull additional attributes based on the type of each <slot>
			switch(tSD.type){
			case "slot":
				//ignore slots that are just 
}
