let idUsuarioLogado;
let idLab;

const api_url = "http://visionpeekapi.azurewebsites.net/peek/";

function setIdUsuario(id) {
    if (idUsuarioLogado == undefined) {
        idUsuarioLogado = id;
    }
}

function setIdLab(id) {
    if (id != undefined) {
        idLab = id;
    }
}

function pegarConsumoDownloadUploadLaboratorios() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede/?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
//            console.log(response + "download/upload");
            attChartGoogle(response.Download, response.Upload);
        },
        error: function () {

        }
    });

}


function pegarConsumoDownloadLaboratorios() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede/?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
       //     console.log(response.Download + "download");
            

            atualizaDrawConsume(response.Download, "aaa");//response.Data);
        },
        error: function () {

        }
    });

}

function pegarQuantidadeDeLaboratorios() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Laboratorio/?idUsuario=" + idUsuarioLogado+"&oque=quantidade",
        data: '',
        success: function (response) {


            document.getElementById("txtQuantidadeLaboratorio").textContent = response;
           
        },
        error: function () {

        }
    });
}

function pegarQuantidadeDePC() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Computador?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
          //  console.log(response);
        },
        error: function () {

        }
    });
}

function pegarProcessosQueMaisConsumemHardware() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Processo?idUsuario=" + idUsuarioLogado + "&oque=labUsando",
        data: '',
        success: function (response) {
          //  console.log(response[0]);
            let arrayProcessos = response;
            let processos = new Array();
            let quantidadeProcesso = new Array();

            for (var i = 0; i < 5; i++){
                try {
                    processos.push(arrayProcessos[i].Nome);
                    quantidadeProcesso.push(arrayProcessos[i].QuantidadeProcessos);
                } catch (Exception){ }
            }
          //  console.log(processos+" aaaaaaaaaaaaaaaaaa "+quantidadeProcesso)
            atualizaDrawMoreUseGraphi(processos, quantidadeProcesso);

        },
        error: function () {

        }
    });
}

function pegarProcessosQueMaisConsumemInternet() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Processo?idUsuario=" + idUsuarioLogado + "&oque=usaInternet",
        data: '',
        success: function (response) {
            let arrayProcessos = response;
            let processos = new Array();
            let quantidadeProcesso = new Array();

            for (var i = 0; i < 5; i++) {
                try {
                    processos.push(arrayProcessos[i].Nome);
                    quantidadeProcesso.push(arrayProcessos[i].QuantidadeProcessos);
                } catch (Exception) { }
            }
         //  console.log(processos + " aaaaaaaaaaaaaaaaaa " + quantidadeProcesso)
            atualizaDrawUseGraphi(processos, quantidadeProcesso);
        },
        error: function () {

        }
    });
}

function pegarTodosLaboratorioDeUmUsuario() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede?idUsuario=" + idUsuarioLogado + "&oque=labs",
        data: '',
        success: function (response) {
          //  console.log(response);
        },
        error: function () {

        }
    });
}

function pegarTodosLabs() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Laboratorio/?oque=labs&idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
           
           
        },
        error: function () {

        }
    });
}

function pegarInformacoesPC(idComputador) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Computador/?contexto=individual&id=" + idComputador,
        data: '',
        success: function (response) {
         //   console.log(response);
            
        },
        error: function () {

        }
    });
}

function pegarInformacoesCompletasPC(idComputador) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "InfoComputador/?idComputador=" + idComputador,
        data: '',
        success: function (response) {
          //  console.log(response);
           
        },
        error: function () {

        }
    });
}

function pegarInformacoesPcPorLab(idLab) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Computador/?contexto=laboratario&id=" + idLab,
        data: '',
        success: function (response) {
         //   console.log(response);
          
        },
        error: function () {

        }
    });
}

function pegarMediaPorcetagemUsoComputador() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Processador/?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
            
            atualizaDrawInfraProcessHistory(response, "ddd");
        },
        error: function () {

        }
    });
}

function pegarMediaPorcetagemUsoRam() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "MemoriaRam/?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
            document.getElementById("mediaUsoMemoriaRam").textContent = response + "% (RAM)";
        },
        error: function () {

        }
    });
}


function pegarMediaPorcetagemUsoProcessador() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "MemoriaRam/?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
            document.getElementById("mediaUsoProcessador").textContent = response + "% (PROCESSADOR)";
        },
        error: function () {

        }
    });
}

let baixa = document.getElementById("baixa_utilizacao");
let media = document.getElementById("media_utilizacao");
let alta = document.getElementById("alta_utilizacao");

function pegarLaboratoriosQueMaisConsomem() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede/?idUsuario=" + idUsuarioLogado + "&oque=consumoPorLab",
        data: '',
        success: function (response) {

            let baixa = document.getElementById("baixa_utilizacao");
            let array = response;
            let size = array.length;

            baixa.textContent = array[0].Nome;
            media.textContent = array[Math.floor((size / 2))].Nome;
            alta.textContent = array[size-1].Nome;

        },
        error: function () {

        }
    });
}

