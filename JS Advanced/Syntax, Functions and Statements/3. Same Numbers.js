function sameNumbers(input) {
    let numberToString = input.toString();
    let areEqual = true;
    let sum = 0;
    let length = numberToString.length;
    let numAtFirstIndex = numberToString[0];

    for (i = 0; i < length; i++) {
        sum += Number(numberToString[i]);

        if (numberToString[i] != numAtFirstIndex) {
            areEqual = false;
        }
    }

    console.log(areEqual);
    console.log(sum);
}

