using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessingAlgoritham
{
   public  class slidingWindow
    {
        // this problem based on the dynamic window
        public static string find_Longest_substring_with_k_distintCharacter(string word,int k_disticnt) {

            Dictionary<char, int> map = new Dictionary<char, int>();
            int windowStart = 0;
            int windowEnd = 0;
            int maxstart = windowStart;
            int maxEnd = windowEnd;
            
            while (windowEnd<word.Length) {

                if (map.Keys.Count > k_disticnt)
                {
                    map[word[windowStart]]--;
                    if (map[word[windowStart]] == 0)
                    {
                        map.Remove(word[windowStart]);
                    }
                    windowStart++;
                }
                else
                {
                   
                    if (map.Keys.Count == k_disticnt) {
                        if ((windowEnd - windowStart) > (maxEnd - maxstart)) {
                            maxstart = windowStart;
                            maxEnd = windowEnd;
                        }

                    }

                    if (map.ContainsKey(word[windowEnd]))
                    {
                        map[word[windowEnd]]++;
                    }
                    else {
                        map[word[windowEnd]] = 1;
                    }

                    windowEnd++;
                }
            }


            return word.Substring(maxstart, (maxEnd - maxstart));
        }

        public static int find_the_longest_substring_with_k_distinctCharater(string word,int k_distinct) {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int windowStart = 0;
            int windowEnd = 0;
            int maxWindowStart = 0;
            int MaxWIndowEnd = 0;

            while (windowEnd < word.Length) {
                if (map.Keys.Count > k_distinct)
                {
                    map[word[windowStart]]--;

                    if (map[word[windowStart]] == 0) { 
                        map.Remove(word[windowStart]);
                    }

                    windowStart++;
                }
                else {

                        if (map.Keys.Count == k_distinct) {
                          if ((windowEnd - windowStart) > (MaxWIndowEnd - maxWindowStart)) {
                            maxWindowStart = windowStart;
                            MaxWIndowEnd = windowEnd;
                            }
                      }

                        if (map.ContainsKey(word[windowEnd]))
                     {
                         map[word[windowEnd]]++;
                     }
                        else {
                        map[word[windowEnd]] = 1;
                     }

                    windowEnd++;
                }

               
            }
            return (MaxWIndowEnd - maxWindowStart);
        }

        public static string find_the_smallest_substring_with_k_distinctCharacter(string word,int K_distinct) {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int windowStart = 0;
            int windowEnd = 0;
            int minimumStart = 0;
            int minimumEnd = int.MaxValue;

            while (windowEnd < word.Length) {
                if (map.Keys.Count > K_distinct)
                {
                    // decreasing the window size as follows 
                    map[word[windowStart]]--;

                    if (map[word[windowStart]] == 0)
                    {
                        map.Remove(word[windowStart]);
                    }

                    windowStart++;
                }
                else {
                    
                    if (map.Keys.Count == K_distinct)
                    {
                        if ((windowEnd-windowStart) < (minimumEnd-minimumStart)) {
                            minimumEnd = windowEnd;
                            minimumStart = windowStart;
                        }
                    
                    }

                    if (map.ContainsKey(word[windowEnd]))
                    {
                        map[word[windowEnd]]++;
                    }
                    else {
                        map[word[windowEnd]] = 1;
                    }

                    windowEnd++;
                    
                }
                
            }
            return word.Substring(minimumStart, (minimumEnd - minimumStart));
        }
    }
}







