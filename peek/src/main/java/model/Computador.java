package model;

import controller.RedeController;
import controller.HDController;
import controller.ProcessoController;

public class Computador {

    private MemoriaRam ram;
    private HDController HD;
    private Processador processador;
    private RedeController rede;
    private ProcessoController processo;

    public Computador() {
        ram = new MemoriaRam();
        HD = new HDController();
        processador = new Processador();
        rede = new RedeController();
        processo = new ProcessoController();
    }

    public MemoriaRam getRam() {
        return ram; 
    }

    public HDController getHD() {
        return HD;
    }

    public Processador getProcessador() {
        return processador;
    }

    public RedeController getRede() {
        return rede;
    }

    public ProcessoController getProcesso() {
        return processo;
    }

}
