$(function(){
    $("form").on("submit", function(e){
        e.preventDefault();

        //cria variavel prar validar e enviar nome do lab pro BD
        var nome = $(this).find("input[name=nome-lab]").val().trim();
        console.log(nome);
        
        if(nome == null || nome == ""){
            alert("É preciso preencher o nome do laboratório!");
            return;
        } 
        
        //Faz requisição pro back e recupera o id do lab
        var idLab;
        $(".projects").append(
            "<div class=\"item\" id='"+idLab+"'>\n\
                <div class=\"legenda\">"+nome+"</div>\n\
                <a href=\"#\" class=\"btn-dark\">\n\
                        <i class=\"fas fa-desktop\"></i> Adicionar maquinas\n\
                </a>\n\
                <a href=\"#\" class=\"btn-dark\">\n\
                        <i class=\"fas fa-chart-line\"></i> Ir para o painel\n\
                </a>\n\
            </div>");
    });
});