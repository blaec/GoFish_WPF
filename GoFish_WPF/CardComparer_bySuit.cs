using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GoFish_WPF
{
    class CardComparer_bySuit : IComparer<Card>
    {
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            int result = x.Suit > y.Suit ? 1 : -1;
            if (x.Suit == y.Suit)
            {
                result = x.Value == y.Value
                    ? 0
                    : (x.Value > y.Value
                        ? 1
                        : -1);

            }
            return result;
        }
    }
}
