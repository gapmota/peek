package model;

import controller.RedeController;
import controller.HDController;
import controller.ProcessoController;

public class Computador {

    public MemoriaRam getRam() {
        return new MemoriaRam();
    }

    public HDController getHD() {
        return new HDController();
    }

    public Processador getProcessador() {
        return new Processador();
    }

    public RedeController getRede() {
        return new RedeController();
    }
    
    public ProcessoController getProcesso(){
        return new ProcessoController();
    }

}
