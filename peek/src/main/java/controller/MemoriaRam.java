package controller;

import oshi.SystemInfo;
import oshi.util.FormatUtil;

public class MemoriaRam {

    private SystemInfo systemInfo = null;

    /**
     *
     * @return Retorna o total de RAM em GB
     */
    public long getTotal() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getMemory().getTotal();
    }

    /**
     *
     * @return Retorna o total disponivel de RAM em GB
     */
    public long getDisponivel() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getMemory().getAvailable();
    }

    /**
     *
     * @return Retorna o total em uso de RAM em GB
     */
    public long getUsando() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getMemory().getTotal() - systemInfo.getHardware().getMemory().getAvailable();
    }

}
