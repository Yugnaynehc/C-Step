namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private PlayingCard[,] cardPack;
        private Random randomCardSelector = new Random();

		public Pack()
		{
            // to do - initialize the pack of cards
		}

        public PlayingCard DealCardFromPack()
        {
            // to do - pick a random card, remove it from the pack, and return it
            throw new NotImplementedException("DealCardFromPack - TBD");
        }

        private bool IsSuitEmpty(Suit suit)
        {
            // to do - return true if there are no more cards available in this suit
            throw new NotImplementedException("IsSuitEmpty - TBD");
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
           // to do - return true if this card has already been dealt   
            throw new NotImplementedException("IsCardAlreadyDealt - TBD");
        }
	}
}