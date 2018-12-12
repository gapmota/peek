let modal = document.getElementById("modal_process");

function abrirModal(div) {

    if (modal.className = 'fnd_modal_machines_off') {
        modal.className = 'fnd_modal_machines_on';

        pegarInformacoesCompletasPC(div.id);        

    } else {
        modal.className = 'fnd_modal_machines_off';
    }

}

function fechar() {
    modal.className = 'fnd_modal_machines_off';
    document.getElementById("area_processos").innerHTML = "";
}

function finalizarProcesso(div) {

    let array = div.id.split("-");

    let idPc = array[0];
    let processo = array[1];

    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: "http://visionpeekapi.azurewebsites.net/peek/Processo/?idComputador=" + idPc + "&processo=" + processo + "&oque=finalizar",
        data: '',
        success: function (response) {

            alert(response);

        },
        error: function () {

        }
    });

    


}