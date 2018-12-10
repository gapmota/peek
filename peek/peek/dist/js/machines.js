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
