namespace BiggerIsGreater_Solution
{
    using System.Text;

    public static class BiggerIsGreaterAlgorithm
    {
        /// <summary>
        /// Algorithm: getting the right value and move to the left looking for the first value which is less.
        /// Example #1: [ 1 1 1 3 ] -> [ 1 1 3 1 ] - good!
        /// Example #2: [ 1 2 3 1 ] -> 1 - is not moved -> [ 1 3 2 1 ] -> verified: [ 1 3 ] -> sort [ 2 1 ] -> [ 1 2 ] -> [ [ 1 3 ] [ 1 2] ] -> [ 1 3 1 2 ]
        /// Example #3: [ 1 4 7 5 3 0 ] -> 0 is ok -> 3 can be swapped with 1, checking the medium numberss ->
        ///                 [ 4 7 5 ] -> 5 can be swapped with 4 -> [ 5 7 4 ] -> 
        ///                     in full array swap 5 and 4 then sort numbers after '4'.  
        ///                 
        /// </summary>
        /// <param name="w">Initial string.</param>
        /// <returns>Next bigger string.</returns>
        public static string Run(string w)
        {
            if (w == String.Concat(w.OrderByDescending(c => c)))
            {
                return "no answer";
            }

            SwapPair? swapPair = GetSwapPair(w);

            List<char> dataList = new List<char>();
            dataList.AddRange(w);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            char a = dataList[swapPair.Index2];
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // Swapping 2 items
            dataList[swapPair.Index2] = dataList[swapPair.Index1];
            dataList[swapPair.Index1] = a;

            string newString = new string(dataList.ToArray());

            // Getting numbers after the right swapped one.
            string remainedSubString = newString.Substring(swapPair.Index2 + 1);
            
            // Sort them.
            string sortedRemainedSubString = String.Concat(remainedSubString.OrderBy(c => c));

            // Merge everything in one result.
            string result = newString.Substring(0, swapPair.Index2 + 1) + sortedRemainedSubString;

            return result;
        }
        
        
        public static string GetNextBiggerString(string w)
        {
            for (int i = w.Length - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (w[j] < w[i])
                    {
                        w = GetStringWithSwappedChars(w, i, j);

                        string validPartOfString = w.Substring(0, j + 1);
                        string notVerifiedPartOfString = w.Substring(j + 1);

                        return validPartOfString + BiggerIsGreaterAlgorithm.GetNextBiggerString(notVerifiedPartOfString);
                    }
                }
            }

            return w;
        }

        private static string GetStringWithSwappedChars(string initialString, int idx1, int idx2)
        {
            StringBuilder stringBuilder = new StringBuilder(initialString);

            // Used tuple to swap values
            (stringBuilder[idx2], stringBuilder[idx1]) = (stringBuilder[idx1], stringBuilder[idx2]);

            return stringBuilder.ToString();
        }

        public static SwapPair? GetSwapPair(string w)
        {
            // right-to-left direction
            int index1; // the rightIndex
            int index2 = -1; // the left index

            for (int i = w.Length - 1; i > 0; i--)
            {
                index1 = i;
                for (int j = i; j >= 0; j--)
                {
                    // looking for the next item which valus is less
                    if (w[j] < w[i])
                    {
                        index2 = j;
                        break;
                    }
                }
                
                // the operations are performed only if the next item with less value is found
                if (index2 != -1)
                {
                    // if there are still items between the found two, we canot guarantee the must be swapped.
                    // looking for the values to swap in the between subsequence.
                    if (index1 - index2 > 1)
                    {
                        // Ejecting a substring between left 'index2' and right 'index1' 
                        string subString = w.EjectString(index2 + 1, index1 - 1);

                        // Getting swap pair from the ejected substring.
                        SwapPair swapPair = GetSwapPair(subString);

                        // if the swaping values are found, adapt their coordinates by adding the index of the right value.
                        if (swapPair != null)
                        {
                            swapPair.Index2 += index2 + 1;
                            swapPair.Index1 += index2 + 1;

                            return swapPair;
                        }
                    }

                    return new SwapPair
                    {
                        Index2 = index2,
                        Index1 = index1
                    };
                }
            }

            return null;
        }
    }
}
