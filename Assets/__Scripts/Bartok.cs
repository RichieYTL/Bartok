﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartok : MonoBehaviour {
	static public Bartok S;
	public TextAsset deckXML;
	public TextAsset layoutXML;
	public Vector3 layoutCenter = Vector3.zero;

	public Deck deck;
	public List<CardBartok> drawPile;
	public List<CardBartok> discardPile;
	void Awake() {
		S = this;
	}
	void Start () {
		deck = GetComponent<Deck>();
		deck.InitDeck(deckXML.text);
		Deck.Shuffle(ref deck.cards);
	}
}
