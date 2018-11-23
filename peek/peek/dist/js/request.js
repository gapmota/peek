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

function pegarConsumoDownloadUploadLaboratorios(download, upload, idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede/?idUsuario=" + idUsuario,
        data: '',
        success: function (response) {
            download.text(response.Download);
            upload.text(response.Upload);
        },
        error: function () {

        }
    });

}

function pegarQuantidadeDeLaboratorios(laboratorio, idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Laboratorio/?idUsuario=" + idUsuario,
        data: '',
        success: function (response) {
            console.log(response);
            laboratorio.text(response);
        },
        error: function () {

        }
    });
}

function pegarQuantidadeDePC(idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Computador?idUsuario=" + idUsuario,
        data: '',
        success: function (response) {
            console.log(response);
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
        url: api_url + "Processo?idUsuario=" + idUsuario + "&oque=labUsando",
        data: '',
        success: function (response) {
            console.log(response);
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
        url: api_url + "Processo?idUsuario=" + idUsuario + "&oque=usaInternet",
        data: '',
        success: function (response) {
            console.log(response);
        },
        error: function () {

        }
    });
}

function pegarTodosLaboratorioDeUmUsuario(idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede?idUsuario=" + idUsuario + "&oque=labs",
        data: '',
        success: function (response) {
            console.log(response);
        },
        error: function () {

        }
    });
}

function pegarTodosLabs(idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Laboratorio/?oque=labs&idUsuario=" + idUsuario,
        data: '',
        success: function (response) {
            console.log(response);
            laboratorio.text(response);
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
            console.log(response);
            laboratorio.text(response);
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
            console.log(response);
            laboratorio.text(response);
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
            console.log(response);
            laboratorio.text(response);
        },
        error: function () {

        }
    });
}

function pegarMediaPorcetagemUsoComputador(idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Processador/?idUsuario=" + idUsuario,
        data: '',
        success: function (response) {
            console.log(response);
            laboratorio.text(response);
        },
        error: function () {

        }
    });
}


function pegarLaboratoriosQueMaisConsomem(idUsuario) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "Rede/?idUsuario=" + idUsuario + "&oque=consumoPorLab",
        data: '',
        success: function (response) {
            console.log(response);
            laboratorio.text(response);
        },
        error: function () {

        }
    });
}

window.onload = function () {//ao carregar a pagina
    setIdUsuario(4);
    pegarConsumoDownloadUploadLaboratorios($("#txtDownload"), $("#txtUpload"), idUsuarioLogado);
    pegarQuantidadeDeLaboratorios($("#txtQuantidadeLaboratorio"), idUsuarioLogado);
};

setInterval(function () {//um minuto
    pegarConsumoDownloadUploadLaboratorios($("#txtDownload"), $("#txtUpload"), idUsuarioLogado);

}, 10000);

setInterval(function () {//dez minutos
    pegarQuantidadeDeLaboratorios($("#txtQuantidadeLaboratorio"), idUsuarioLogado);
}, 100000);