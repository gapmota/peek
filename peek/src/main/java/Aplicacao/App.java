package Aplicacao;

import java.io.Console;

import oshi.SystemInfo;

public class App {
	public static void main(String[] args) {
		
		Computador c = new Computador();
		
		String[] mac = c.getRede().getMacsPC();
		
		for(int i = 0; i < mac.length; i++) {
			System.out.println(mac[i]);
		}
		
		System.out.println();
		
		System.out.println(c.getRede().getMAC());
		System.out.println(c.getRede().getVelocidadeDownload());
		System.out.println(c.getRede().getVelocidadeUpload());
		
		System.out.println(new SystemInfo().getHardware().getNetworkIFs()[0].getBytesRecv());
		
	}
}
