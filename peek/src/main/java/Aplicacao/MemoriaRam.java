package Aplicacao;

import oshi.SystemInfo;

public class MemoriaRam {
	
	private SystemInfo systemInfo = new SystemInfo();
	//1048576 MB
	//1073741824 GB
	
	/**
	 * 
	 * @return Retorna o total de RAM em GB
	 */
	public long getTotal() {
		return systemInfo.getHardware().getMemory().getTotal() / 1073741824;
	}
	
	/**
	 * 
	 * @return Retorna o total disponivel de RAM em GB
	 */
	public long getDisponivel() {
		return systemInfo.getHardware().getMemory().getAvailable() / 1073741824;
	}
	
	/**
	 * 
	 * @return Retorna o total em uso de RAM em GB
	 */
	public long getUsando() {
		return getTotal() - getDisponivel();
	}
	
	
}
