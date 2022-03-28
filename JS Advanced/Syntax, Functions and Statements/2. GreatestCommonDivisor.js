function greatestCommonDevisor(numberOne, numberTwo) {

    let smallerNumber = numberOne < numberTwo ? numberOne : numberTwo;
    let devisor = 1;

    for (let i = 2; i <= smallerNumber; i++) {
        if (numberOne % i == 0 && numberTwo % i == 0) {
            devisor = i;
        }
    }

    console.log(devisor);
}


