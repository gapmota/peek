package aplicacao;

import controller.ComputadorController;
import controller.RedeController;
import controller.UsuarioController;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.Usuario;
import view.JanelaCadastrarPC;
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
