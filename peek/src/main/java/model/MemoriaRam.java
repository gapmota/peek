package model;

import oshi.SystemInfo;
import oshi.util.FormatUtil;

public class MemoriaRam {

    private SystemInfo systemInfo = null;

    /**
     *
     * @return Retorna o total de RAM em GB
     */
    public double getTotal() {
        systemInfo = new SystemInfo();
        return this.toDouble(systemInfo.getHardware().getMemory().getTotal());

    }

    /**
     *
     * @return Retorna o total disponivel de RAM em GB
     */
    public double getDisponivel() {
        systemInfo = new SystemInfo();
        return this.toDouble(systemInfo.getHardware().getMemory().getAvailable());

    }

    /**
     *
     * @return Retorna o total em uso de RAM em GB
     */
    public double getUsando() {
        systemInfo = new SystemInfo();
        return this.getTotal() - this.getDisponivel();

    }

    public int getPorcentagemUso() {

        return (int) ((this.getUsando() * 100.0) / this.getTotal());
    }

    /**
     * RETORNA UM VALOR EM BYTE PARA GB USANDO O FormUtil
     *
     * @param num
     * @return byte para gb em double
     */
    private double toDouble(long num) {
        return Double.parseDouble(FormatUtil.formatBytes(num).split(" ")[0].replace(",", "."));
    }

}
