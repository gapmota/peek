package controller;

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

    public Rede getRede() {
        return new Rede();
    }

}
