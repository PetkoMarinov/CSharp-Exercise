function fruitPrice(fruit, weightInGrams, priceInKg){
    let weightInKg = weightInGrams / 1000;
    let result = (weightInKg * priceInKg).toFixed(2);
    
    console.log(`I need $${result} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

