package aplicacao;

import controller.*;
import java.sql.SQLException;
import java.util.List;
import model.Particao;

public class App {

    public static void main(String[] args) throws InterruptedException, SQLException {

        Computador a = new Computador();
        ComputadorController cc = new ComputadorController();

        cc.cadastroInicial();

       
        while (true) {
            cc.atualizacaoAutomatica();
            Thread.sleep(60000); //1 minuto
        }
    }
}
