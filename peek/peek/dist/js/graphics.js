let dataGoogle;
let optionsGoogle;
let chartGoogle;

let consumeGraphi;
let chartConsume;

let useGraphi;
let chartUse;

let moreUseGraphi;
let chartMoreUse;

let infraProcessHistory;
let chartUseProcessHistory;

function drawConsumeGraphi() {
    consumeGraphi = document.getElementById('consumeGraphi').getContext('2d');

    chartConsume = new Chart(consumeGraphi, {
        type: 'line',
        data: {
            datasets: [{

                label: 'Consumo',
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
    //  console.log("aqui mano");
}


function drawInfraProcessHistory() {

    infraProcessHistory = document.getElementById('infraHistory').getContext('2d');
    infraProcessHistory.canvas.width = 70;
    infraProcessHistory.canvas.height = 23;

    chartUseProcessHistory = new Chart(infraProcessHistory, {
        type: 'line',
        data: {
            //labels: ['2000', '2001', '2002', '2003'],
            datasets: [{
                label: 'Desempenho',
                //data: [30, 45, 80, 100],
                backgroundColor: "rgba(255, 34, 0, 0.3)",
                borderColor: "#0000ff",
                label: 'Uso da rede',
                //data: [173448346, 175885229, 178276128, 180619108],
                backgroundColor: "rgba(0,225,29,0.3)",
                borderColor: "rgb(235,46,188)"
            }],

        }
    });
}



function atualizaDrawInfraProcessHistory(consumo, data) {

    if (chartUseProcessHistory.data.labels.length == 6) {
        chartUseProcessHistory.data.labels.splice(0, 1);
        chartUseProcessHistory.data.datasets[0].data.splice(0, 1);
    }

    chartUseProcessHistory.data.labels.push(data);
    chartUseProcessHistory.data.datasets[0].data.push(consumo);
    chartUseProcessHistory.update();
    //  console.log("aqui mano 2");
}



function drawUseGraphi() {
    useGraphi = document.getElementById('useGraphi').getContext('2d');
    chartUse = new Chart(useGraphi, {
        type: 'bar',
        data: {
            //labels: ['google chrome', 'netbeans', 'steam', 'outlook'],
            datasets: [{
                label: 'Processos que usam internet',
                //data: [100, 2, 4, 4],
                backgroundColor: "rgba(0,225,29,0.3)",
                borderColor: "rgb(235,46,188)",
                borderWidth: 1
            }]
        }
    });
}

function drawMoreUseGraphi() {
    moreUseGraphi = document.getElementById('infraMoreUse').getContext('2d');
    moreUseGraphi.canvas.width = 70;
    moreUseGraphi.canvas.height = 23;

    chartMoreUse = new Chart(moreUseGraphi, {
        type: 'bar',
        data: {
            // labels: ['2000', '2001', '2002', '2003'],
            datasets: [{
                label: 'Processos mais usados',
                //   data: [173448346, 175885229, 178276128, 180619108],
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


function atualizaDrawMoreUseGraphi(processo, quantidade) {


    chartMoreUse.data.labels = processo;
    chartMoreUse.data.datasets[0].data = quantidade;
    chartMoreUse.update();

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
        
        redFrom: 90, redTo: 100,
        yellowFrom: 51, yellowTo: 100,
        greenFrom: 0, greenTo: 50,
        minorTicks: 5    };

    chartGoogle = new google.visualization.Gauge(document.getElementById('procGraphi'));

    chartGoogle.draw(dataGoogle, optionsGoogle);


}


function attChartGoogle(download, upload) {
    try {
        dataGoogle.setValue(0, 1, download);
        chartGoogle.draw(dataGoogle, optionsGoogle);

        dataGoogle.setValue(1, 1, upload);
        chartGoogle.draw(dataGoogle, optionsGoogle);
    } catch (Exception) { }
}

function seeMaquinas() {
    window.location.href = "machines.aspx";
}

function seeLabs() {
    window.location.href = "addLab.aspx";
}