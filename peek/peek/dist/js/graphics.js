let consumeGraphi = document.getElementById('consumeGraphi').getContext('2d');
   
var chart = new Chart(consumeGraphi, {
    type: 'line',
    data: {
        labels: ['2000', '2001', '2002', '2003'],
        datasets: [{
            label: 'Crescimento Populacional',
            data: [173448346, 175885229, 178276128, 180619108],
            backgroundColor: "rgba(255, 34, 0, 0.3)",
            borderColor: "#0000ff"
        }]
            }
});

let useGraphi = document.getElementById('useGraphi').getContext('2d');

var chart = new Chart(useGraphi, {
    type: 'bar',
    data: {
        labels: ['2000', '2001', '2002', '2003'],
        datasets: [{
            label: 'Crescimento Populacional',
            data: [173448346, 175885229, 178276128, 180619108],
            backgroundColor: "rgba(255, 34, 0, 0.3)",
            borderColor: "#0000ff"
        }]
    }
});



