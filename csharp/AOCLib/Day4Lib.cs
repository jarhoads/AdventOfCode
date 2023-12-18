using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOCLib.Models;

namespace AOCLib;
public class Day4Lib
{
    public static CardData ConvertToCardData(string row, int rowNum)
    {
        // get card number
        var cardNumbers = row.Split(':');
        var cardNumber = cardNumbers[0];
        var number = cardNumber.Split(" ")[1];

        // get winners
        var cardWinners = cardNumbers[1].Split("|")[0];
        var winners = cardWinners.Trim().Split(" ").Select(winner => InputUtil.ToDigit(winner)).Where(num => num > 0).ToList();

        // get haves
        var cardHaves = cardNumbers[1].Split("|")[1];

        var have = cardHaves.Trim().Split(" ").Select(winner => InputUtil.ToDigit(winner)).Where(num => num > 0).ToList();

        var card = new CardData(winners, have) { Id = rowNum };

        return card;

    }

    public static List<int> CardWinners(List<int> winners, List<int> have) 
    {
        return winners.IntersectBy(have, num => num).ToList();
    }

    public static int CardPoints(List<int> cardWinners)
    {
        return (cardWinners.Count > 0) ? (int)Math.Pow(2.0, (cardWinners.Count - 1)) : 0;
    }

    public static int CardsWon(List<CardData> cards)
    {
        // I was trying to get this to work with recursion
        // because I thought it would be more elegant, but this works so I gave up
        int[] cardCount = new int[cards.Count];
        
        // count 1 for each card
        for (int i = 0; i < cardCount.Length; i++) { cardCount[i] = 1; }

        // update cards with win counts
        for (int cardId = 0; cardId < cards.Count; cardId++)
        {
            var card = cards[cardId];
            var wins = CardWinners(card.Winners, card.Have);
            var numWon = wins.Count;

            for (int i = 0; i < numWon; i++)
            {
                var updateForCard = cardId + 1 + i;
                cardCount[updateForCard] += cardCount[cardId];
            }
        }

        return cardCount.Sum();
    }

}
