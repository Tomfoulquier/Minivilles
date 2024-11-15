using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minivilles
{
    public class Pile
    {
        public List<Card> listCards = new List<Card>();

        public Pile()
        {
        }
        public void AddCard(Card card)
        {
            listCards.Add(card);
            return;
        }
    }
}
