package controller;

import oshi.SystemInfo;

public class Processador {
	private SystemInfo systemInfo = new SystemInfo();
	
	public String getNomeProcessador() {
		
		return systemInfo.getHardware().getProcessor().getName();
		
	}
	
	public String getResumoProcessador() {
		String processador = "";
		
		processador += "Nome: "+systemInfo.getHardware().getProcessor().getName()+"\n";
		processador += "Nucleos: "+systemInfo.getHardware().getProcessor().getLogicalProcessorCount()+"\n";
		processador += "Usado: "+(systemInfo.getHardware().getProcessor().getSystemCpuLoad() * 100)+" %\n";
		processador += "Sistem ativo a: "+(systemInfo.getHardware().getProcessor().getSystemUptime() / 60)+" Minutos";
		
		return processador;
	}
	
	public double getVoltagem() {
		return systemInfo.getHardware().getSensors().getCpuVoltage();
	}
	
	public double getTemperatura() {
		return systemInfo.getHardware().getSensors().getCpuTemperature();
	}
	
	public int[] getVelocidadeFans() {
		return systemInfo.getHardware().getSensors().getFanSpeeds();
	}
	
	public int getPorcetagemDeUso() {
		return (int)(systemInfo.getHardware().getProcessor().getSystemCpuLoad() * 100.0);
	}
}
