package controller;

import oshi.SystemInfo;
import oshi.util.FormatUtil;

public class MemoriaRam {

    private SystemInfo systemInfo = null;

    /**
     *
     * @return Retorna o total de RAM em GB
     */
    public String getTotal() {
        systemInfo = new SystemInfo();
        return FormatUtil.formatBytes(systemInfo.getHardware().getMemory().getTotal());
    }

    /**
     *
     * @return Retorna o total disponivel de RAM em GB
     */
    public String getDisponivel() {
        systemInfo = new SystemInfo();
        return FormatUtil.formatBytes(systemInfo.getHardware().getMemory().getAvailable());
    }

    /**
     *
     * @return Retorna o total em uso de RAM em GB
     */
    public String getUsando() {
        systemInfo = new SystemInfo();
        long uso = systemInfo.getHardware().getMemory().getTotal() - systemInfo.getHardware().getMemory().getAvailable();
        return FormatUtil.formatBytes(uso);
    }

}
