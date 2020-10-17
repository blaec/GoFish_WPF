using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoFish_WPF
{
    [Serializable]
    class Deck
    {
        private List<Card> cards;
        

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card((Suits)suit, (Values)value));
                }
            }
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal()
        {
            return Deal(0);
        }

        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Card temp = Deal(random.Next(0, cards.Count));
                cards.Add(temp);
            }
        }

        public IEnumerable<string> GetCardNames()
        {
            return cards.Select(m => m.ToString()).ToList();
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }

        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        public bool ContainsValue(Values value)
        {
            return cards.Any(c => c.Value == value);
        }

        public Deck PullOutValues(Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                if (cards[i].Value == value)
                {
                    deckToReturn.Add(Deal(i));
                }
            }

            return deckToReturn;
        }

        public bool HasBook(Values value)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    NumberOfCards++;
                }
            }
            return NumberOfCards == 4;
        }
    }
}
