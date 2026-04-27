using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class CardGame : MonoBehaviour
{

    public List<Sprite> sprites = new List<Sprite>();
    public List<Card> cards = new List<Card>();
    private Card firstCard = null;
    private Card SecondCard = null;
    private bool isChecking = false;
    

    void Start()
    {
        startGame();
    }

    void startGame()
    {
        List<int> pairNumbers = GeneratePairNumbers(cards.Count);
        for (int i = 0; i < pairNumbers.Count; ++i)
        {
            cards[i].SetCardNumber(pairNumbers[i]);


            cards[i].SetFrontImage(sprites[pairNumbers[i]]);
        }

       
    }


    void CheckCard()
    {
    
        isChecking = true;

        if(firstCard.number == SecondCard.number)
        {
           
            firstCard. ChangeColor(Color.red);
            SecondCard.ChangeColor(Color.red);

            firstCard.isMatched = true;
            SecondCard.isMatched =true;

            firstCard = null;
            SecondCard = null;

            isChecking = false;
        }
        else
        {
            Invoke("HideCard", 1.0f);

            
        }
    }

    public void OnClickCard(Card card)
    {
        if (isChecking)
        {
            return;
        }

        if (firstCard == null)
        {
            firstCard = card;
            firstCard.Flip(true);
        }
        else
        {
            SecondCard = card;
            SecondCard.Flip(true);
        }
        if (firstCard != null && SecondCard != null)
        {
            CheckCard();
        }
    }


    void HideCard()
    {
        firstCard.isFront = false;
        SecondCard.isFront = false;

        firstCard.Flip(false);
        SecondCard.Flip(false);

        firstCard = null;
        SecondCard = null;

        isChecking = false;
    }

    List<int> GeneratePairNumbers(int cardCount)
    {
 
        int pairCount = cardCount / 2;
        List<int> newCardNumbers = new List<int>();


        for (int i = 0; i < pairCount; ++i)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }


        for (int i = newCardNumbers.Count - 1; i > 0; i--)
        {
            int temp = newCardNumbers[i];
            int rnd = Random.Range(0, i + 1);
            
            newCardNumbers[i] = newCardNumbers[rnd];
            newCardNumbers[rnd] = temp;
        }

        return newCardNumbers;

    }
}
