package aplicacao;

import controller.*;
import java.sql.SQLException;
import oshi.util.FormatUtil;

public class App {

    public static void main(String[] args) throws InterruptedException, SQLException {

        Computador a = new Computador();
        ComputadorController cc = new ComputadorController();
        
        cc.cadastroInicial();
        
        
        
        while (true) {
            cc.atualizacaoAutomatica();
            Thread.sleep(5000); //1 minuto
        }
    }
}
