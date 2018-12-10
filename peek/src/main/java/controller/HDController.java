package controller;

import dao.ComputadorDAO;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import oshi.SystemInfo;
import oshi.hardware.HWDiskStore;
import oshi.software.os.OSFileStore;

public class HDController {

    private ComputadorDAO pcDAO = null;
    private String mensagemPadraoParticao = "###";
    private SystemInfo systemInfo = null;

    private boolean isParticaoValida(String nome) {
        return !nome.trim().equals(mensagemPadraoParticao);
    }

    public List<OSFileStore> getInformacoesHd() {
        OSFileStore[] hds = new SystemInfo().getOperatingSystem().getFileSystem().getFileStores();
        List<OSFileStore> listOS = new ArrayList<>();
        String ret = "";
        for (int i = 0; i < hds.length; i++) {

            if (hds[i].getDescription().equalsIgnoreCase("Fixed drive")) {
                listOS.add(new OSFileStore(hds[i].getName(), hds[i].getVolume(), hds[i].getMount(), hds[i].getDescription(), hds[i].getType(), hds[i].getUUID(), hds[i].getUsableSpace(), hds[i].getTotalSpace()));
            }
        }

        return listOS;

    }

    private long getEspacoUsadoParticao(int indexHD, int indexParticao) {
        systemInfo = new SystemInfo();
        //return systemInfo.getHardware().getDiskStores()[indexHD].getPartitions()[indexParticao].get
        return 00000;//systemInfo.getHardware().getDisk;
    }

    public void atualizarHd() {
        pcDAO = new ComputadorDAO();
        try {
            pcDAO.atualizarHd();
        } catch (SQLException ex) {
            Logger.getLogger(HDController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    private int getQuantidadeParticoes(int indexHD) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[indexHD].getPartitions().length;
    }

    private String[] getIdentificadorHD() {
        systemInfo = new SystemInfo();
        int qntDisco = getQuantidadeDisco();
        String[] serialHD = new String[qntDisco];
        for (int i = 0; i < qntDisco; i++) {
            serialHD[i] = systemInfo.getHardware().getDiskStores()[i].getSerial();
        }
        return serialHD;

    }

    /**
     * @return Retorna a quantida de disco
     */
    private int getQuantidadeDisco() {
        systemInfo = new SystemInfo();
        System.out.println("------------------------- " + systemInfo.getHardware().getDiskStores().length);
        return systemInfo.getHardware().getDiskStores().length;
    }

    /**
     * @return Retorna o espaço total de um disco em GIGA passando o index do
     * disco
     */
    private long getEspacoTotal(int index) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[index].getSize();// / 1073741824;
    }

    /**
     * @return Retorna o espaço em uso de um disco em GIGA passando o index do
     * disco
     */
    private long getEspacoUsado(int index) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[index].getSize();// / 1073741824;
    }

    /**
     * @return Retorna o espaço disponível de um disco em GIGA passando o index
     * do disco
     */
    /**
     * @return Retorna o espaço total da partição de um disco em GIGA passando o
     * index do disco
     */
    private long getEspacoTotalParticao(int indexHd, int indexParticao) {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[indexHd].getPartitions()[indexParticao].getSize();// / 1073741824;
    }

    /**
     * @return Retorna o nome da partição
     */
    private String getNomeParticao(int indexHd, int indexParticao) {
        systemInfo = new SystemInfo();
        String nome = systemInfo.getHardware().getDiskStores()[indexHd].getPartitions()[indexParticao].getMountPoint();

        if (nome.trim().equals("")) {
            return mensagemPadraoParticao;
        } else {
            return nome;
        }
    }

    private long getLeitura(int index) {
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
