package aplicacao;

import controller.ComputadorController;
import controller.RedeController;
import java.sql.SQLException;
import view.JanelaLogin;
import view.JanelaModelIniciandoMonitoramento;

public class App {

    public static void main(String[] args) throws InterruptedException, SQLException {
       
        
        
        if(new ComputadorController().isPcJaCadastrado(new RedeController().getMacsPC())){
            new JanelaModelIniciandoMonitoramento();
            new ComputadorController().coletarInformacoes();
            new ComputadorController().enviarSlack();
            
        }else{
            new JanelaLogin();
        }
                
        /*
        

*/
        
    }
}
