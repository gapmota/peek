package Aplicacao;

import java.io.Console;

public class App {
	public static void main(String[] args) {
		
		System.out.println(resumo());
		
	}
	
	
	public static String resumo() {
		String rs = "";
		
		Computador c = new Computador();
		
		rs = c.getProcessador().getNomeProcessador()+"\n";
		rs += c.getProcessador().getResumoProcessador()+"\n";
		rs += c.getProcessador().getPorcetagemDeUso()+"\n";
		rs += c.getProcessador().getTemperatura()+"\n";
		rs += c.getProcessador().getVelocidadeFans()+"\n";
		rs += c.getProcessador().getVoltagem()+"\n";
		rs += "\n-------------------------------------------\n";
		rs += "\n-------------------------------------------\n";
		rs += "\n-------------------------------------------\n";
		rs += c.getHD().getArvore()+"\n";
		rs += c.getHD().getNomeParticao(0, 1)+"\n";
		rs += c.getHD().getEspacoDisponivel(0)+"\n";
		rs += c.getHD().getEspacoTotal(0)+"\n";
		rs += c.getHD().getEspacoTotalParticao(0, 0);
		rs += c.getHD().getEspacoUsado(0);
		rs += c.getHD().getLeitura(0);
		rs += c.getHD().getQuantidadeDisco();
		rs += "\n-------------------------------------------\n";
		rs += "\n-------------------------------------------\n";
		rs += "\n-------------------------------------------\n";
		rs += c.getRam().getDisponivel()+"\n";
		rs += c.getRam().getTotal()+"\n";
		rs += c.getRam().getUsando()+"\n";
		rs += "\n-------------------------------------------\n";
		rs += "\n-------------------------------------------\n";
		rs += "\n-------------------------------------------\n";
		rs += c.getRede().getAdaptadorDeRede(1)+"\n";
		rs += c.getRede().getIPv4(1)+"\n";
		rs += c.getRede().getIPv6(1)+"\n";
		rs += c.getRede().getMAC(1)+"\n";
		rs += c.getRede().getTotalInterfaces()+"\n";
		rs += c.getRede().getVelocidade(1);
		
		return rs;
	}
	
}
