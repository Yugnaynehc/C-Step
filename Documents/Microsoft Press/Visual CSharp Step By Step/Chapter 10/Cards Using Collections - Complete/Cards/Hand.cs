namespace Cards
{
	using System;
	using System.Collections;

	class Hand
	{
        public const int HandSize = 13;
        private ArrayList cards = new ArrayList();

		public void AddCardToHand(PlayingCard cardDealt)
		{
            if (this.cards.Count >= HandSize)
            {
                throw new ArgumentException("Too many cards");
            }
            this.cards.Add(cardDealt);
		}

		public override string ToString()
		{
			string result = "";
			foreach (PlayingCard card in this.cards)
			{
				result += card.ToString() + "\n";
			}

			return result;
		}
	}
}