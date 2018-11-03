package controller;

import java.util.Date;
import oshi.SystemInfo;

public class Processador {

    private SystemInfo systemInfo = null;

    public String getNomeProcessador() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getProcessor().getName();
    }

    public String getResumoProcessador() {
        systemInfo = new SystemInfo();
        String processador = "";

        processador += "Nome: " + systemInfo.getHardware().getProcessor().getName() + "\n";
        processador += "Nucleos: " + systemInfo.getHardware().getProcessor().getLogicalProcessorCount() + "\n";
        processador += "Usado: " + (systemInfo.getHardware().getProcessor().getSystemCpuLoad() * 100) + " %\n";
        processador += "Sistem ativo a: " + (systemInfo.getHardware().getProcessor().getSystemUptime() / 60) + " Minutos";

        return processador;
    }

    public double getVoltagem() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getSensors().getCpuVoltage();
    }

    public double getTemperatura() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getSensors().getCpuTemperature();
    }

    public int[] getVelocidadeFans() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getSensors().getFanSpeeds();
    }

    public int getPorcetagemDeUso() {
        systemInfo = new SystemInfo();
        return (int) (systemInfo.getHardware().getProcessor().getSystemCpuLoad() * 100.0);
    }

    public String getTempoAtividade() {
        systemInfo = new SystemInfo();
        return new Date(systemInfo.getHardware().getProcessor().getSystemUptime()).toString();
    }
    
    public String getIdProcessadorOSHI(){
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getProcessor().getProcessorID();
    }
    
    
}
