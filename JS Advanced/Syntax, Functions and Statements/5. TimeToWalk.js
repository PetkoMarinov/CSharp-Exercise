function calculate(steps, footprint, speed) {
    let distance = steps * footprint / 1000;
    let breaks = Math.floor(distance / 0.5);
    let totalTimeInSeconds = (distance / speed) * 3600 + breaks * 60;

    let seconds = (totalTimeInSeconds % 60).toFixed().padStart(2,'0');
    let minutes = Math.floor(totalTimeInSeconds / 60).toFixed().padStart(2,'0');
    let hours = Math.floor(totalTimeInSeconds / 3600).toFixed().padStart(2,'0');
    
    return console.log(`${hours}:${minutes}:${seconds}`);
}

calculate(2564, 0.70, 5.5);
