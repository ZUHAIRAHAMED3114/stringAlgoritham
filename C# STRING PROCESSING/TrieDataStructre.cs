using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessingAlgoritham
{
    public class TrieNode {
        public char character { get; set; }

        public bool hasChildren { get { return !(childrens == null); } }
        public TrieNode[] childrens { get; set; }
        public int wordCOunt { get; set; }
        public TrieNode(char character) {
            this.character = character;
        }
   
    }
    public class TrieDataStructure
    {
        public TrieNode Root;
        public TrieDataStructure() {
            Root = new TrieNode(' ');
        }

        public void InsertWord(string word) {
            if (word == null) throw new ArgumentNullException();
     

            TrieNode current = Root;

            for (int i = 0; i < word.Length; i++) {

                int currentWordPosition = word[i] - (int)'a';
                if (current.childrens == null) {
                    current.childrens = new TrieNode[26];
                }
                if (current.childrens[currentWordPosition] == null)
                {
                    current.childrens[currentWordPosition] = new TrieNode(word[i]);
                }

                current = current.childrens[currentWordPosition];

                if (i+1==word.Length) {
                    current.wordCOunt++;
                }

            }


        }

        public bool HasValue(string word) {
            if (word == null) return false;

            var current = this.Root;
            for (int i=0;i<word.Length;i++) {
                if (current.childrens[(word[i] - (int)'a')] is null)
                {
                    return false;
                }
                else {
                    current = current.childrens[(word[i] - (int)'a')];
                }

                if (i + 1 == word.Length) {
                    if (current.wordCOunt > 0) {
                        return true;
                    }
                }
            }

            return false;
        }


        public void DeleteWord(string word) {
            var current = Root;
            for (int i=0;i<word.Length;i++) {
                int currentPOsition = word[i] - (int)'a';
                if (current.childrens[currentPOsition] == null) {
                    return;
                }
                if (i + 1 == word.Length) {
                    if (current.childrens[currentPOsition].wordCOunt > 0)
                    {
                            current.childrens[currentPOsition].wordCOunt--;
                    }

                    return;
                }
                current = current.childrens[currentPOsition];

            }

        }
    }
}
