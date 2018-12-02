//seleciona itens do html

//usa queryselector para 'pegar' classes criada no html
const menuBtn = document.querySelector('.menu-btn');
const menu = document.querySelector('.menu');
const menuNav = document.querySelector('.menu-nav');
const menuBranding = document.querySelector('.menu-branding');

const navItems = document.querySelectorAll('.nav-item');

//cria variavel com estado inicial falso
let showMenu = false;

//adiciona funcao de click chamada toggleMenu
menuBtn.addEventListener('click', toggleMenu);

function toggleMenu(){
    if(!showMenu){
        menuBtn.classList.add('close');
        menu.classList.add('show');
        menuNav.classList.add('show');
        menuBranding.classList.add('show');
        //cria uma array list para adicionar 'show' em cada item da lista menu (na clase de casa menu)
        navItems.forEach(item => item.classList.add('show'));

        //redefini o memnu novamente   
        showMenu = true; 
    }else{
        menuBtn.classList.remove('close');
        menu.classList.remove('show');
        menuNav.classList.remove('show');
        menuBranding.classList.remove('show');
        navItems.forEach(item => item.classList.remove('show'));

        //redefini o menu novamente   
        showMenu = false; 
    }
}



//TENTATIVA JS DASHBOARD
const dashBtn = document.querySelector('.btn-dash');
const legendaMaster = document.querySelector('#dashboardInfra');

//cria variavel com estado inicial falso
let showDash = false;

//adiciona funcao de click chamada toggleMenu
dashBtn.addEventListener('click', toggleDash);

function toggleDash(){
    if(!showDash){
        dashBtn.classList.add('close');
        legendaMaster.classList.add('show');        

        //redefini o memnu novamente   
        showDash = true; 
    }else{
        dashBtn.classList.remove('close');
        legendaMaster.classList.remove('show');

        //redefini o menu novamente   
        showDash = false; 
    }
}


window.onload = function () {//ao carregar a pagina
    setIdUsuario(4);

    google.charts.load('current', { 'packages': ['gauge'] });
    google.charts.setOnLoadCallback(drawChart);

    drawConsumeGraphi();
    drawUseGraphi();
    drawMoreUseGraphi();
    drawInfraProcessHistory();

    pegarConsumoDownloadUploadLaboratorios();

    pegarConsumoDownloadLaboratorios();

    
};


setInterval(() => {
  //  atualizaDrawConsume(Math.floor(Math.random() * 50), '21-21-21');
},1000);

