let input = document.getElementById("txtComandoParaSerExecutado");
let btn = document.getElementById("btn_executar_comando");

let idLab;
let barraTitulo = document.getElementById("titulo_cmd");

const api_url = "http://visionpeekapi.azurewebsites.net/peek/";

let area_prompt = document.getElementById("area_prompt_remoto");

let div_bloco_prompt_temp;

function abrirModalCmd(id) {
    setIdLab(id);
    document.getElementById("modal_cmd").className = "modal_cmd_on";
    barraTitulo.textContent = "prompt remoto ~ laboratorio " + id;
    document.getElementById("digite_sem_texto").textContent = "laboratorio " + id + ">";
}



function fecharModalCmd() {
    document.getElementById("modal_cmd").className = "modal_cmd_off";
    area_prompt.innerHTML = "";
}


function setIdLab(id) {
    idLab = id;
}

input.onclick = function () {
    //addTextoPromptRemoto(input.value,"sem retorno");
}

btn.onclick = function () {



    var texto = input.value;

    if (texto.trim() != "") {

        addTextoPromptRemoto(texto);
        input.value = "";
        barraTitulo.textContent = "prompt remoto ~ laboratorio " + idComputador + " [EXECUTANDO]";

    }



}

function addTextoPromptRemoto(comando) {

    div_bloco_prompt_temp = "";

    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        },
        url: api_url + "CmdRemoto/?idLab=" + idLab + "&comando=" + comando,
        data: '',
        success: function (response) {

            div_bloco_prompt_temp =
                "<div class='bloco_prompt'> "
                + "<p id='cmd_executado'>laboratorio " + idLab + "> " + comando + "</p>";


            let listTemp = response.split(';');

            console.log(listTemp);

            for (var i = 0; i < listTemp.length; i++) {

                //    console.log(listTemp[i]);

                div_bloco_prompt_temp += "<p id='retorno_executado'> " + listTemp[i] + "</p>";
            }

            div_bloco_prompt_temp += "</div>";

            area_prompt.innerHTML += "<p><p><p></p>" + div_bloco_prompt_temp;
            barraTitulo.textContent = "prompt remoto ~ idLab " + idComputador;
        },

        error: function () {
            barraTitulo.textContent = "prompt remoto ~ idLab " + idComputador + " [ERRO AO EXECUTAR COMANDO] ";

            div_bloco_prompt_temp =
                "<div class='bloco_prompt'> "
                + "<p id='cmd_executado'>idLab " + idComputador + "> " + response[j].Comando + "</p>";


            div_bloco_prompt_temp += "<p id='retorno_executado'>idLab não responde... assim que possível será executado o comando.</p>";


            div_bloco_prompt_temp += "</div>";

            area_prompt.innerHTML += "<p><p><p></p>" + div_bloco_prompt_temp;
        }
    });
}



