function getRandom() {
    return Math.floor(Math.random() * 100);
}

let tempoPadrao = 5000;
let tempoPadraoLinhas = 10000;

setInterval(() => {//30 seg


    pegarLaboratoriosQueMaisConsomem();

}, tempoPadrao);



setInterval(() => {//30 seg


    pegarConsumoDownloadUploadLaboratorios();


}, tempoPadrao);

setInterval(() => {//30 seg

    pegarProcessosQueMaisConsumemHardware();



}, tempoPadrao);

setInterval(() => {
    pegarProcessosQueMaisConsumemInternet();
    //  console.log("aqui");
}, tempoPadrao);

setInterval(() => {

    pegarMediaPorcetagemUsoComputador();

}, tempoPadraoLinhas);

setInterval(() => {//30 seg


    pegarMediaPorcetagemUsoRam();

}, tempoPadrao);

setInterval(() => {//um minuto
    pegarConsumoDownloadLaboratorios();
}, tempoPadraoLinhas);



setInterval(() => {//um minuto
    pegarQuantidadeHDsQuePossuemPoucoEspaco();
}, tempoPadrao);


setInterval(() => {//um minuto
    pegarQuantidadeHDsQuePossuemMuitoEspaco();
}, tempoPadrao);


setInterval(() => {//um minuto
    pegarQuantidadeHDsQuePossuemEspacoIdeal();
}, tempoPadrao);

setInterval(() => {//dez minutos
    pegarMediaPorcetagemUsoComputador();
}, tempoPadrao);






