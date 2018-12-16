let idUsuarioLogado;
let idLab;

let porcetagemMinimaHD;
let porcetagemMaximaHD;

let diretorioHD;

function setPorcetagensUsoHDeDiretorio(min,max,diretorio) {
    if (porcetagemMinimaHD == undefined) {
        porcetagemMinimaHD = min;
        porcetagemMaximaHD = max;
        diretorioHD = diretorio
    }
}

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

            atualizaDrawConsume(response.Download, "");
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
            let arrayProcessos = response;
            let processos = new Array();
            let quantidadeProcesso = new Array();

            for (var i = 0; i < 5; i++){
                try {
                    processos.push(arrayProcessos[i].Nome);
                    quantidadeProcesso.push(arrayProcessos[i].QuantidadeProcessos);
                } catch (Exception){ }
            }
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
            mostrarInfosPc(response);
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
            
            atualizaDrawInfraProcessHistory(response, "");
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
            document.getElementById("mediaUsoMemoriaRam").textContent = response + "%";
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
        url: api_url + "Processador/?idUsuario=" + idUsuarioLogado,
        data: '',
        success: function (response) {
            document.getElementById("mediaUsoProcessador").textContent = response + "%";
        },
        error: function () {

        }
    });
}














let baixa_rede = document.getElementById("baixa_utilizacao");
let media_rede = document.getElementById("media_utilizacao");
let alta_rede = document.getElementById("alta_utilizacao");

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

            let array = response;
            let size = array.length;

            alta_rede.textContent = array[0].Nome;
            media_rede.textContent = array[Math.floor((size / 2))].Nome;
            baixa_rede.textContent = array[size - 1].Nome;
            
        },
        error: function () {

        }
    });
}

let pouco_hd = document.getElementById("pouco_hd");
let media_hd = document.getElementById("media_hd");
let muito_hd = document.getElementById("muito_hd");

function pegarQuantidadeHDsQuePossuemPoucoEspaco() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Hd/?idUsuario=" + idUsuarioLogado + "&porc=" + porcetagemMinimaHD + "&diretorio=" + diretorioHD + "&oque=poucoEspaco",
        data: '',
        success: function (response) {

            pouco_hd.textContent = response;

        },
        error: function () {

        }
    });
}

function pegarQuantidadeHDsQuePossuemMuitoEspaco() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Hd/?idUsuario=" + idUsuarioLogado + "&porc=" + porcetagemMinimaHD + "&diretorio=" + diretorioHD + "&oque=espacoLivre",
        data: '',
        success: function (response) {

            muito_hd.textContent = response;

        },
        error: function () {

        }
    });
}


function pegarQuantidadeHDsQuePossuemEspacoIdeal() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Hd/?idUsuario=" + idUsuarioLogado + "&porcIncial=" + porcetagemMinimaHD + "&porcFinal=" + porcetagemMaximaHD + "&diretorio=" + diretorioHD + "&oque=espacoIdeal",
        data: '',
        success: function (response) {

            media_hd.textContent = response;

        },
        error: function () {

        }
    });
}


let id_pc = document.getElementById("id_computador_modal");
let processador = document.getElementById("processador_modal");
let ram = document.getElementById("ram_modal");
let download = document.getElementById("downladUpload_modal");
let hd = document.getElementById("hd_modal");

let cnx = document.getElementById("area_processos");

function mostrarInfosPc(json) {
    

    id_pc.textContent = json.Computador.IdComputador;
    processador.textContent = json.Computador.DescricaoProcessador + " | Usando: " + json.Processador.PorcentagemUso + "%";
    ram.textContent = "Memoria Ram Total: " + json.MemoriaRam.Total + " | Em uso: " + json.MemoriaRam.PorcentagemUso + "%";
    download.textContent = "Download: " + json.Rede.VelocidadeDownload + " | Upload: " + json.Rede.VelocidadeUpload;
    hd.textContent = "HD: ";

    for (var i = 0; i < json.Hd.length; i++) {
        hd.textContent += json.Hd[i].Diretorio + " usando " + json.Hd[i].PorcentagemUso + "% | ";
    }

    for (var i = 0; i < json.Processos.length; i++) {
        cnx.innerHTML += "<div class='processo_detalhe'>" +

            "<label class='estilo_texto_detalhe' id= 'nome_processo'>" + json.Processos[i].Nome + "</label >" +
            "<label class='estilo_texto_detalhe' id='uso_ram_processo'>" + bytesToSize(json.Processos[i].MemoriaRamUsada) + "</label>" +

            "<div class='btn_finalizar_processo' id='" + json.Computador.IdComputador + "-" + json.Processos[i].Nome + "' onclick='finalizarProcesso(this)'>Finalizar</div>" +
            "</div >";
    }



}

function bytesToSize(bytes) {
    var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    if (bytes == 0) return '0 Byte';
    var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
    return Math.round(bytes / Math.pow(1024, i), 2) + ' ' + sizes[i];
};


