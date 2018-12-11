package aplicacao;

import controller.ComputadorController;
import controller.NotificacaoController;
import controller.RedeController;
import java.sql.SQLException;
import view.JanelaLogin;
import view.JanelaModelIniciandoMonitoramento;

public class App {

    public static void main(String[] args) throws InterruptedException, SQLException {
<<<<<<< HEAD
       
        
         /* if(new ComputadorController().isPcJaCadastrado(new RedeController().getMacsPC())){
              //LOGIN AUTOMATICO PQ JA TEM O PC CADASTRADO
=======
          
          if(new ComputadorController().isPcJaCadastrado(new RedeController().getMacsPC())){
>>>>>>> af3c40938b6334f0733373bbfd6cde3e7b4e78a5
            new JanelaModelIniciandoMonitoramento();
            new log_peek.arquivoLog("login automatico, computador já cadastrado");
            new ComputadorController().coletarInformacoes();
            new NotificacaoController().iniciarSistema();
            
        }else{*/
            new JanelaLogin();
<<<<<<< HEAD
            new log_peek.arquivoLog("abrindo tela de login");
        }
                
        /*
        

*/
        
=======
            new NotificacaoController().iniciarSistema();
        }    
>>>>>>> af3c40938b6334f0733373bbfd6cde3e7b4e78a5
    }
}
