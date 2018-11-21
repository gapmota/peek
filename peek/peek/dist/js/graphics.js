   let primeiroGrafico = document.getElementById('primeiroGrafico').getContext('2d');
   
var chart = new Chart(primeiroGrafico, {
    type: 'bar',
    data: {
        labels: ['2000', '2001', '2002', '2003', '2004', '2005'],
        datasets: [{
            label: 'Crescimento Populacional',
            data: [173448346, 175885229, 178276128, 180619108],
            backgroundColor: "rgba(255, 34, 0, 0.3)",
            borderColor: "#0000ff"
        }]
            }
});
