function naviePatternMatch(Text, Pattern) {
    for (let i = 0; i < Text.length; i++) {
        let j = 0;
        while (Text[i + j] === Pattern[j]) {
            j++;
        }
        if (j === Pattern.length) {
            return true;
        }
    }

    return false;
}
var text = "ABCDEFAGHIEJAJABCDAABACABCDABCYYABCDAABCY";
var pattern = "ABCDABCY";
console.log(naviePatternMatch(text, pattern));