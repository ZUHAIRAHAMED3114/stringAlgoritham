// first construct the hashFucntion
// next construnct the recalculatehashFuncton 
// finally calculate Rabinkarp Function
const primeNumber = 5381;

function hashFunction(Words) {

    let hashvalue = 0;
    for (let index = 0; index < Words.length; index++) {
        hashvalue += Math.pow(primeNumber, index) * Words.charCodeAt(index);
    }

    return hashvalue;
}

function reCalculateHashFuncton(oldWord, newWord, oldHash) {
    let newHash = oldHash - Math.pow(primeNumber, 0) * Words.charCodeAt(0);
    newHash = newHash / primeNumber;
    return newHash + Math.pow(primeNumber, oldWord - 1) * Words.charCodeAt(oldWord.length - 1);
}

function RabinKarpPatternMatch(text, pattern) {
    let oldvalue = text.substr(0, pattern.length);
    const patternHashvalue = hashFunction(pattern);
    let oldHashValue = hashFunction(oldvalue);
    if (oldHashValue === patternHashvalue) {
        return true;
    }

    for (let i = 1; i < text.length; i++) {
        let newvalue = text.substr(i, pattern.length);
        let newHashvaleu = hashFunction(oldvalue, newvalue, oldHashValue);
        if (newHashvaleu === patternHashvalue) {
            return true;
        } else {
            oldHashValue = newHashvaleu;
            oldvalue = newvalue;
        }
    }

    return false;
}


var text = "ABCDEFAGHIEJAJABCDAABACABCDABCYYABCDAABCY";
var pattern = "ABCDABCY";
console.log(RabinKarpPatternMatch(text, pattern));