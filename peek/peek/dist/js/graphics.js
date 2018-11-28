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
            //labels: ['2000', '2001', '2002', '2003'],
            datasets: [{
                label: 'Uso da rede',
                //data: [173448346, 175885229, 178276128, 180619108],
                backgroundColor: "rgba(0,225,29,0.3)",
                borderColor: "rgb(235,46,188)"
            }],

        }
    });
}

function atualizaDrawConsume(consumo, data) {
   
        if (chartConsume.data.labels.length == 6) {
            chartConsume.data.labels.splice(0, 1);
            chartConsume.data.datasets[0].data.splice(0, 1);
        }

        chartConsume.data.labels.push(data);
        chartConsume.data.datasets[0].data.push(consumo);
        chartConsume.update();
        console.log("aqui mano");
}

function drawUseGraphi() {
    useGraphi = document.getElementById('useGraphi').getContext('2d');

    chartUse = new Chart(useGraphi, {
        type: 'bar',
        data: {
            //labels: ['google chrome', 'netbeans', 'steam', 'outlook'],
            datasets: [{
                label: 'Processos em uso',
                //data: [100, 2, 4, 4],
                backgroundColor: "rgba(0,225,29,0.3)",
                borderColor: "rgb(235,46,188)",
                borderWidth: 1
            }]
        }
    });
}

function atualizaDrawUseGraphi(processo, quantidade) {

    
        chartUse.data.labels = processo;
        chartUse.data.datasets[0].data = quantidade;
        chartUse.update();
  
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