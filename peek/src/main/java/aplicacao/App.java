package aplicacao;

import controller.*;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class App {

    public static void main(String[] args) throws InterruptedException, SQLException {
                       
        new ComputadorController().cadastroInicial();

        new Thread(new Runnable() {
            @Override
            public void run() {
                ComputadorController cc = new ComputadorController();

                while (true) {
                    try {
                        cc.atualizacaoAutomatica();
                        Thread.sleep(10000); //1 minuto
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }

                }
            }
        }).start();

        new Thread(new Runnable() {
            @Override
            public void run() {
                ProcessoController pc = new ProcessoController();

                while (true) {
                    try {
                        System.out.println(pc.insertProcesso() + " processos inseridos");
                        Thread.sleep(10000); //1 minuto
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }

                }
            }
        }).start();
        
        new Thread(new Runnable() {
            @Override
            public void run() {
                HDController hd = new HDController();

                while (true) {
                    try {
                        hd.atualizarHd();
                        Thread.sleep(10000); //1 minuto
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }

                }
            }
        }).start();
        
        new Thread(new Runnable() {
            @Override
            public void run() {
                while(true){
                    ProcessoController pc = new ProcessoController();
                    pc.deleteProcessosParaFinalizar();
                    try {
                        Thread.sleep(10000);
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            }
        }).start();
        
    }
}
