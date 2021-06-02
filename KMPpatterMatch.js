function longestPrefixSuffixArray(Pattern, LpsArray) {
    let i = 0;
    let j = 0;
    LpsArray[0] = 0;
    i++;

    while (i < Pattern.length) {
        if (Pattern[i] === Pattern[j]) {
            LpsArray[i] = j + 1;
            j++;
            i++;
        } else {
            if (j != 0) {
                // we know j is the length of the longest common prefix for i-1 substring 
                // next longest common prefix suffix for   j--> lps[j-1]              
                j = LpsArray[j - 1];
            } else {
                LpsArray[i] = 0;
                i++;
            }

        }

    }
}


function KMPPatternMatch(Text, Pattern) {
    let textIndex = 0;
    let patternIndex = 0;
    let lps = new Array(Pattern.length);
    longestPrefixSuffixArray(Pattern, lps);
    while (textIndex < Text.length) {
        if (Text[textIndex] === Pattern[patternIndex]) {
            textIndex++;
            patternIndex++;
            if (patternIndex === pattern.length) {
                return true;
            }
        } else {
            if (patternIndex != 0) {
                patternIndex = lps[patternIndex - 1]
            } else {
                textIndex++;
            }

        }


    }
    return false;
}


var text = "ABCDEFAGHIEJAJABCDAABACABCDABCYYABCDAABCY";
var pattern = "ABCDABCY";
console.log(KMPPatternMatch(text, pattern));