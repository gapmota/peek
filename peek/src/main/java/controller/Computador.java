package controller;

public class Computador {
	
	private MemoriaRam ram = new MemoriaRam();
	private HD hd = new HD();
	private Processador processador = new Processador();
	private Rede rede = new Rede();
	
	public MemoriaRam getRam() {
		return ram;
	}
	
	public HD getHD() {
		return hd;
	}
	
	public Processador getProcessador() {
		return processador;
	}
	
	public Rede getRede() {
		return rede;
	}
	
}
