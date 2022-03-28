function solve(speed, area) {
    let limits = {
        "motorway": 130,
        "interstate": 90,
        'city': 50,
        'residential': 20
    }

    let diff = speed - limits[area];
    let status = diff > 0 && diff <= 20 ? 'speeding' :
        diff > 20 && diff <= 40 ? 'excessive speeding' :
            'reckless driving';

    switch (true) {
        case diff <= 0:
            console.log(`Driving ${speed} km/h in a ${limits[area]} zone`); break;
        default:
            console.log(`The speed is ${diff} km/h faster than the allowed` +
            ` speed of ${limits[area]} - ${status}`);
    }
}

solve(120, 'interstate')