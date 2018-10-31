package controller;

import oshi.SystemInfo;

public class MemoriaRam {

    private SystemInfo systemInfo = null;

    /**
     *
     * @return Retorna o total de RAM em GB
     */
    public int getTotal() {
        systemInfo = new SystemInfo();
        return (int) systemInfo.getHardware().getMemory().getTotal();
    }

    /**
     *
     * @return Retorna o total disponivel de RAM em GB
     */
    public int getDisponivel() {
        systemInfo = new SystemInfo();
        return (int) systemInfo.getHardware().getMemory().getAvailable();
    }

    /**
     *
     * @return Retorna o total em uso de RAM em GB
     */
    public int getUsando() {
        systemInfo = new SystemInfo();
        return (int) ((int) systemInfo.getHardware().getMemory().getTotal() - systemInfo.getHardware().getMemory().getAvailable());
    }

}
