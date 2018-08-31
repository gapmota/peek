package Aplicacao;

import java.net.SocketException;

import oshi.SystemInfo;

public class Rede {
	private SystemInfo systemInfo = new SystemInfo();
	
	/**
	 * @return Retorna a velocidade da rede em bits
	 */
	
	public int getTotalInterfaces() {
		return systemInfo.getHardware().getNetworkIFs().length;
	}
	
	public long getVelocidade(int index) {		
		return systemInfo.getHardware().getNetworkIFs()[index].getSpeed();		
	}

	public String getIPv4(int index) {
		String[] redes = systemInfo.getHardware().getNetworkIFs()[index].getIPv4addr();
		String infos = "";
		for(int i = 0; i < redes.length; i++) {
			infos += redes[i];
		}
		return infos;
	}
	
	public String getIPv6(int index) {
		String[] redes = systemInfo.getHardware().getNetworkIFs()[index].getIPv6addr();
		String infos = "";
		for(int i = 0; i < redes.length; i++) {
			infos += redes[i];
		}
		return infos;
	}
	
	public String getMAC(int index) {		
		return systemInfo.getHardware().getNetworkIFs()[index].getMacaddr();		
	}

	public String getAdaptadorDeRede(int index) {
		return systemInfo.getHardware().getNetworkIFs()[index].getDisplayName();
	}
	
	
}
