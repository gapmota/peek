package aplicacao;

import controller.ComputadorController;
import controller.RedeController;
import java.sql.SQLException;
import model.MemoriaRam;
import view.JanelaLogin;
import view.JanelaModelIniciandoMonitoramento;

public class App {

    public static void main(String[] args) throws InterruptedException, SQLException {
       
        
         /* if(new ComputadorController().isPcJaCadastrado(new RedeController().getMacsPC())){
              //LOGIN AUTOMATICO PQ JA TEM O PC CADASTRADO
            new JanelaModelIniciandoMonitoramento();
            new log_peek.arquivoLog("login automatico, computador já cadastrado");
            new ComputadorController().coletarInformacoes();
            new ComputadorController().enviarSlack();
            
        }else{*/
            new JanelaLogin();
            new log_peek.arquivoLog("abrindo tela de login");
        }
                
        /*
        

*/
        
    }
}
