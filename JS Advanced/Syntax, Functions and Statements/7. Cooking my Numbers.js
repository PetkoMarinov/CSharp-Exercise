function solve(num, p1, p2, p3, p4, p5) {
    num = Number(num);
    let input = [p1, p2, p3, p4, p5];
    console.log(input.forEach(action(num)));
}

function action(number, command) {
    switch (command) {
        case 'chop': number /= 2;
        case 'dice': number = Math.sqrt(number);
        case 'spice': number++;
        case 'bake': number *= 3;
        case 'fillet': number -= number * 0.20;
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')