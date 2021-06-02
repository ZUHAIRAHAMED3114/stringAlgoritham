using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessingAlgoritham
{
    public class PatternMatching
    {
    
        // time complexity is o(n*m)
        public static bool NavieSolution(string Text,string pattern) {
            if (Text==pattern) {
                return true;   
            }

            int i = 0;
            while (i < Text.Length) {
                int j = 0;
                while (j<pattern.Length && Text[i+j]==pattern[j]) {
                    j++;
                }
                if (j == pattern.Length) 
                    return true;

            }

            return false;
        }

        // time complexity is 0(n)+0(m)
        public static bool KmpSolution(string text,string pattern) {
            int i = 0;
            int j = 0;
            int[] lps = longestPreffixSuffix(pattern);
            while (i<text.Length) {
                if (j < pattern.Length && text[i] == pattern[j])
                {
                    if (text[i] == pattern[j])
                    {
                        j++;
                        i++;
                    }
                }
                else if (j == pattern.Length)
                {
                    return true;
                }
                else {
                    // get the lonest commong prefix for teh legth j
                   j= lps[j - 1];
                }

            }
            return false;
        }

        public static int[] longestPreffixSuffix(string pattern) {
            int[] lps = new int[pattern.Length];
            lps[0] = 0;
            // j is the length of the lps of the i-1 so 
            int j = 0;
            int i = 1;
            while (i<pattern.Length) {
                if (pattern[i] == pattern[j])
                {
                    lps[i] = j + 1;
                    i++;
                    j++;
                }
                else {
                    // getting the next longest common prefix length;
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else {
                        lps[i] = j;
                        i++;
                    }


                }
            }


            return lps;
        }

        private static double HashFunction(string word) {
            double hashValue = 0;

            for (int i=0;i<word.Length;i++) {
               hashValue+= word[i] * Math.Pow(10, word.Length - 1 - i);        
            }

            return hashValue;
        }

        private static double RollingHashFunction(double previousHashValue,string previousStirng,string currentString) {
         
            return  (previousHashValue - previousStirng[0] * Math.Pow(10, previousStirng.Length - 1)) * 10 +
                   currentString[currentString.Length - 1] * Math.Pow(10, 0);    

        }
    
        // here time complexity is 0(n)
        public static bool RabinKarpPatternMatching(string text,string pattern) {
            double patternHashavlue = HashFunction(pattern);
            string curretnwindowText = text.Substring(0, pattern.Length);
            double currentWindowHashvalue = HashFunction(curretnwindowText);
            
            if (patternHashavlue==currentWindowHashvalue) {
                return true;
            }

            for (int i=1;i<(text.Length-pattern.Length);i++) {
                string previousWindowText = curretnwindowText;
                double previousWindowHashVlaue = currentWindowHashvalue;
                curretnwindowText = text.Substring(1, pattern.Length);
                currentWindowHashvalue = RollingHashFunction(previousWindowHashVlaue, previousWindowText, curretnwindowText);
                if (currentWindowHashvalue == patternHashavlue) {
                    return true;
                }
            }

            return false;
        }

        // now comming to the booyer moors algoritham

        public static bool booyerMoorsPatternMatching(string text, string pattern) {
            int i = 0;
            
            while (i<text.Length) {
                int j = pattern.Length;

                while (j > 0 && pattern[j - 1] == text[i + j - 1])
                {
                    j--;
                }
                
                if (j == 0)
                {
                    return true;
                }
                else {
                    i += badMatchRule(text[i + j-1],pattern);

                }          
            }

            return false;
        }

        private static Dictionary<char, int> badmathcTable;
        private static int badMatchRule(char currentWord,string pattern)
        {
            if (badmathcTable == null)
            {
                badmathcTable = new Dictionary<char, int>();
                for (int i=0;i<pattern.Length;i++) {
                    badmathcTable[pattern[i]] = pattern.Length - i;
                }
            }

            return badmathcTable.ContainsKey(currentWord) ? badmathcTable[currentWord]:pattern.Length;
        }
    }
}
