namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private Hashtable cardPack;
        private Random randomCardSelector = new Random();

        public Pack()
        {
            this.cardPack = new Hashtable();

            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                SortedList cardsInSuit = new SortedList();
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    cardsInSuit.Add(value, new PlayingCard(suit, value));
                }
                this.cardPack.Add(suit, cardsInSuit);
            }
        }

        public PlayingCard DealCardFromPack()
        {
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);
            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            Value value = (Value)randomCardSelector.Next(CardsPerSuit);
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            SortedList cardsInSuit = (SortedList)cardPack[suit];
            PlayingCard card = (PlayingCard)cardsInSuit[value];
            cardsInSuit.Remove(value);
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;

            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
            SortedList cardsInSuit = (SortedList)this.cardPack[suit];
            return (!cardsInSuit.ContainsKey(value)); 
        }
	}
}