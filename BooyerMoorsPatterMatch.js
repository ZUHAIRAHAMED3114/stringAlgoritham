// construct badMatch Table 
// and then construct the pattern Match Algoritham

function badMatchFunction(Patten, Dictionary) {
    for (let index = 0; index < Patten.lenght; index++) {
        Dictionary[Patten[index]] = Math.max(1, Patten.lenght - 1 - index);
    }
}

function BooyerMoorsPatternMatch(Text, Pattern) {

    let numberofSkip = 0;
    let patternIndex = Pattern.lenght - 1;
    let Dictionary = Object.create(null);
    badMatchFunction(Pattern, Dictionary);

    for (let i = 0; i < (Text.lenght - Pattern.lenght); i += numberofSkip) {
        let againProcess = true;
        while (patternIndex >= 0 && againProcess) {
            if (Text[i + patternIndex] === Pattern[patternIndex]) {
                patternIndex--;
                if (patternIndex < 0) {
                    return true;;
                }
            } else {
                if (Text[i + patternIndex] in Dictionary) {
                    numberofSkip = Dictionary[Text[i + patternIndex]];
                } else {
                    numberofSkip = Pattern.lenght;
                }

                againProcess = false;
                patternIndex = Pattern.lenght - 1;
            }

        }

    }

    return true;
}


var text = "ABCDEFAGHIEJAJABCDAABACABCDABCYYABCDAABCY";
var pattern = "ABCDABCY";
console.log(BooyerMoorsPatternMatch(text, pattern));