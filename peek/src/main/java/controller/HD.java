package controller;

import oshi.SystemInfo;
import oshi.hardware.HWDiskStore;

public class HD {

    private SystemInfo systemInfo = null;

    /**
     * @return Retorna a quantida de disco
     */
    public int getQuantidadeDisco() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores().length;
    }

    /**
     * @return Retorna o espaço total de um disco em GIGA passando o index do
     * disco
     */
    public long getEspacoTotal(int index) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[index].getSize();// / 1073741824;
    }

    /**
     * @return Retorna o espaço em uso de um disco em GIGA passando o index do
     * disco
     */
    public long getEspacoUsado(int index) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[index].getSize();// / 1073741824;
    }

    /**
     * @return Retorna o espaço disponível de um disco em GIGA passando o index
     * do disco
     */
    public long getEspacoDisponivel(int index) {
        systemInfo = new SystemInfo();
        return getEspacoTotal(index) - getEspacoUsado(index);
    }

    /**
     * @return Retorna o espaço total da partição de um disco em GIGA passando o
     * index do disco
     */
    public long getEspacoTotalParticao(int indexHd, int indexParticao) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[indexHd].getPartitions()[indexParticao].getSize();// / 1073741824;
    }

    /**
     * @return Retorna o nome da partição
     */
    public String getNomeParticao(int indexHd, int indexParticao) {
        systemInfo = new SystemInfo();
        String nome = systemInfo.getHardware().getDiskStores()[indexHd].getPartitions()[indexParticao].getMountPoint();

        if (nome.trim().equals("")) {
            return "###";
        } else {
            return nome;
        }
    }

    public long getLeitura(int index) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[index].getTransferTime();
    }

    /**
     * @return Retorna a arvore de todos os disco
     */
    public String getArvore() {
        systemInfo = new SystemInfo();
        String arvore = "";

        HWDiskStore[] hd = systemInfo.getHardware().getDiskStores();

        for (int i = 0; i < getQuantidadeDisco(); i++) {

            int indexParticao = hd[i].getPartitions().length;

            long total = getEspacoTotal(i);
            long gb = total / 1073741824;

            if (gb > 0) {
                arvore += hd[i].getName() + " " + gb + " GB\n";
            } else {

                long mb = total / 1048576;

                if (mb > 0) {
                    arvore += hd[i].getName() + " " + mb + " MB\n";
                } else {
                    arvore += hd[i].getName() + " " + total + " bytes\n";
                }

            }

            for (int j = 0; j < indexParticao; j++) {

                total = getEspacoTotalParticao(i, j);
                gb = total / 1073741824;

                if (gb > 0) {
                    arvore += "\tParticão " + getNomeParticao(i, j) + " Total: " + gb + " GB \n";
                } else {

                    long mb = total / 1048576;

                    if (mb > 0) {
                        arvore += "\tParticão " + getNomeParticao(i, j) + " Total: " + mb + " MB \n";
                    } else {
                        arvore += "\tParticão " + getNomeParticao(i, j) + " Total: " + total + " bytes \n";
                    }

                }

            }
        }

        return arvore;
    }

}
