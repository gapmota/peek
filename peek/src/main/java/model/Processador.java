package model;

import java.text.DecimalFormat;
import java.util.concurrent.TimeUnit;
import oshi.SystemInfo;
import oshi.util.FormatUtil;

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
        systemInfo.getOperatingSystem().getManufacturer();  
        return this.converterMilliParaHoras(systemInfo.getHardware().getProcessor().getSystemUptime());
    }

    public String getIdProcessadorOSHI() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getProcessor().getProcessorID();
    }

    public String converterMilliParaHoras(long mi) {
        System.out.println(FormatUtil.formatElapsedSecs(mi));
        return FormatUtil.formatElapsedSecs(mi);
                //dfHoras.format(horas)+":"+df.format(minutos)+":"+df.format(segundos);
    }
}
