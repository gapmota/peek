let dataGoogle;
let optionsGoogle;
let chartGoogle;

let consumeGraphi;
let chartConsume;

let useGraphi;
let chartUse;


function drawConsumeGraphi() {
    consumeGraphi = document.getElementById('consumeGraphi').getContext('2d');

    chartConsume = new Chart(consumeGraphi, {
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
}

function drawUseGraphi() {
    useGraphi = document.getElementById('useGraphi').getContext('2d');

    chartUse = new Chart(useGraphi, {
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
}




function drawChart() {

    dataGoogle = google.visualization.arrayToDataTable([
        ['Label', 'Value'],
        ['Download', 100],
        ['Upload', 100],
    ]);

    optionsGoogle = {
        width: 400,
        height: 240,
        colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6']
    };

    chartGoogle = new google.visualization.Gauge(document.getElementById('procGraphi'));

    chartGoogle.draw(dataGoogle, optionsGoogle);

}

function attChartGoogle(download, upload) {
    dataGoogle.setValue(0, 1, download);
    chartGoogle.draw(dataGoogle, optionsGoogle);

    dataGoogle.setValue(1, 1, upload);
    chartGoogle.draw(dataGoogle, optionsGoogle);
}