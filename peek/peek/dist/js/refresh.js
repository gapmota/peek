function getRandom() {
    return Math.floor(Math.random() * 100);
}

let tempoPadrao = 5000;

setInterval(() => {//30 seg


       pegarLaboratoriosQueMaisConsomem();

}, tempoPadrao);

setInterval(() => {//30 seg


//    pegarLaboratoriosQueMaisConsomem();
    pegarQuantidadeDeLaboratorios();

}, tempoPadrao);

setInterval(() => {//30 seg
    
    
    pegarConsumoDownloadUploadLaboratorios();


}, tempoPadrao);

setInterval(() => {//30 seg

    pegarProcessosQueMaisConsumemHardware();
    
    

}, tempoPadrao);

setInterval(() => {
    pegarProcessosQueMaisConsumemInternet();

}, tempoPadrao);

setInterval(() => {
    
    pegarMediaPorcetagemUsoComputador();
    
}, tempoPadrao);

setInterval(() => {//um minuto
    pegarConsumoDownloadLaboratorios();
}, tempoPadrao);



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
    //  pegarQuantidadeDeLaboratorios($("#txtQuantidadeLaboratorio"), idUsuarioLogado);
}, 100000);






