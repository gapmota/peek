package controller;

public class Computador {

    public MemoriaRam getRam() {
        return new MemoriaRam();
    }

    public HD getHD() {
        return new HD();
    }

    public Processador getProcessador() {
        return new Processador();
    }

    public Rede getRede() {
        return new Rede();
    }

}
