using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GoFish_WPF
{
    class CardComparer_byValue : IComparer<Card>
    {
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            int result = x.Value > y.Value ? 1 : -1;
            if (x.Value == y.Value)
            {
                result = x.Suit == y.Suit
                    ? 0
                    : (x.Suit > y.Suit
                        ? 1
                        : -1);

            }
            return result;
        }
    }
}
