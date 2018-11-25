let idUsuarioLogado;

function setIdUsuario(id){
    if(idUsuarioLogado == undefined){
        idUsuarioLogado = id;
    }
}

function pegarConsumoDownloadUploadLaboratorios(download,upload,idUsuario){    
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: 'http://localhost:55053/peek/Rede/?idUsuario='+idUsuario,
        data: '',
        success: function (response) {
            download.text(response.Download);
            upload.text(response.Upload);        
        },
        error: function () {
            
        }
    });

}

function pegarQuantidadeDeLaboratorios(laboratorio, idUsuario){
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: 'http://localhost:55053/peek/Laboratorio/?oque=quantidade&idUsuario='+idUsuario,
        data: '',
        success: function (response) {
            console.log(response);  
            laboratorio.text(response);    
        },
        error: function () {
            
        }
    });
}

window.onload = function(){//ao carregar a pagina
    setIdUsuario(4);
    pegarConsumoDownloadUploadLaboratorios($("#txtDownload"),$("#txtUpload"),idUsuarioLogado);
    pegarQuantidadeDeLaboratorios($("#txtQuantidadeLaboratorio"),idUsuarioLogado);
};

setInterval(function (){//um minuto
    pegarConsumoDownloadUploadLaboratorios($("#txtDownload"),$("#txtUpload"),idUsuarioLogado);
    
},10000);

setInterval(function (){//dez minutos
    pegarQuantidadeDeLaboratorios($("#txtQuantidadeLaboratorio"),idUsuarioLogado);
},100000);