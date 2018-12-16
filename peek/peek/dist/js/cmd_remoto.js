let input = document.getElementById("txtComandoParaSerExecutado");
let btn = document.getElementById("btn_executar_comando");


let hist = document.getElementById("todos_os_comandos_executados");
let apagr = document.getElementById("limpar_todos_os_comandos");



let idComputador;
let barraTitulo = document.getElementById("titulo_cmd");


let oqueFazer = -1;

let area_prompt = document.getElementById("area_prompt_remoto");

let div_bloco_prompt_temp;

function abrirModalCmd(div) {
    setIdComputador(div.id);
    document.getElementById("modal_cmd").className = "modal_cmd_on";
    barraTitulo.textContent = "prompt remoto ~ computador " + div.id;
    document.getElementById("digite_sem_texto").textContent = "computador " + div.id + ">";
}



function fecharModalCmd() {
    document.getElementById("modal_cmd").className = "modal_cmd_off";
    area_prompt.innerHTML = "";
}


function setIdComputador(id) {
    idComputador = id;
}

input.onclick = function () {
    //addTextoPromptRemoto(input.value,"sem retorno");
}

btn.onclick = function () {



    var texto = input.value;

    if (texto.trim() != "") {

        addTextoPromptRemoto(texto);
        input.value = "";
        barraTitulo.textContent = "prompt remoto ~ computador " + idComputador + " [EXECUTANDO]";

    }



}

hist.onclick = function () {

    addTextoPromptRemotoListarTudo();

}

apagr.onclick = function () {

    addTextoPromptRemotoApagarTudo();

}

function addTextoPromptRemoto(comando) {

    div_bloco_prompt_temp = "";

    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "CmdRemoto/?idComputador=" + idComputador + "&comando=" + comando + "&oque=inserir",
        data: '',
        success: function (response) {

            for (var j = 0; j < response.length; j++) {



                div_bloco_prompt_temp =
                    "<div class='bloco_prompt'> "
                    + "<p id='cmd_executado'>computador " + idComputador + "> " + response[j].Comando + "</p>";


                let listTemp = response[j].Retorno.split(';');

                console.log(listTemp);

                for (var i = 0; i < listTemp.length; i++) {

                    //    console.log(listTemp[i]);

                    div_bloco_prompt_temp += "<p id='retorno_executado'> " + listTemp[i] + "</p>";
                }

                div_bloco_prompt_temp += "</div>";

                area_prompt.innerHTML += "<p><p><p></p>" + div_bloco_prompt_temp;
                barraTitulo.textContent = "prompt remoto ~ computador " + idComputador;
            }
        },
        error: function () {
            barraTitulo.textContent = "prompt remoto ~ computador " + idComputador + " [ERRO AO EXECUTAR COMANDO] ";

            div_bloco_prompt_temp =
                "<div class='bloco_prompt'> "
                + "<p id='cmd_executado'>computador " + idComputador + "> " + response[j].Comando + "</p>";


            div_bloco_prompt_temp += "<p id='retorno_executado'>Computador não responde... assim que possível será executado o comando.</p>";


            div_bloco_prompt_temp += "</div>";

            area_prompt.innerHTML += "<p><p><p></p>" + div_bloco_prompt_temp;
        }
    });





}




function addTextoPromptRemotoListarTudo() {

    div_bloco_prompt_temp = "";

    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "CmdRemoto/?idComputador=" + idComputador + "&comando=x&oque=historico",
        data: '',
        success: function (response) {

            area_prompt.innerHTML = "";
            console.log(response);
            for (var j = 0; j < response.length; j++) {



                div_bloco_prompt_temp =
                    "<div class='bloco_prompt'> "
                    + "<p id='cmd_executado'>computador " + idComputador + "> " + response[j].Comando + "</p>";


                let listTemp = response[j].Retorno.split(';');

                //  console.log(listTemp);

                for (var i = 0; i < listTemp.length; i++) {

                    //   console.log(listTemp[i]);

                    div_bloco_prompt_temp += "<p id='retorno_executado'> " + listTemp[i] + "</p>";
                }

                div_bloco_prompt_temp += "</div>";

                area_prompt.innerHTML += "<p><p><p></p>" + div_bloco_prompt_temp;
            }
        },
        error: function () {

        }
    });





}


function addTextoPromptRemotoApagarTudo() {

    div_bloco_prompt_temp = "";

    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "CmdRemoto/?idComputador=" + idComputador + "&comando=x&oque=apagar",
        data: '',
        success: function (response) {

            area_prompt.innerHTML = "";

        },
        error: function () {

        }
    });





}




