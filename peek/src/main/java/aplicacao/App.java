package aplicacao;

import controller.*;

public class App {

    public static void main(String[] args) {

        ComputadorController cc = new ComputadorController();
        System.out.println(cc.cadastroInicial());

        cc.atualizacaoAutomatica();

    }

}
