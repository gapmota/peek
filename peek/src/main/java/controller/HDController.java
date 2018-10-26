package controller;

import java.util.ArrayList;
import java.util.List;
import oshi.SystemInfo;
import oshi.hardware.HWDiskStore;
import model.HD;
import model.Particao;

public class HDController {
    
    private String mensagemPadraoParticao = "###";
    private SystemInfo systemInfo = null;
    
    private boolean isParticaoValida(String nome){
        return !nome.trim().equals(mensagemPadraoParticao);           
    }
    
    public List<HD> getInformacoesHdParticao(){
        List<HD> listaHD = new ArrayList<>();
        
        String[] identificadorHD = this.getIdentificadorHD();
               
        
        for(int i = 0; i < identificadorHD.length; i++){
            HD hd = new HD();            
            hd.setIdentificador(identificadorHD[i]);
            hd.setUsado(this.getEspacoUsado(i));
            hd.setTotal(this.getEspacoTotal(i)); 
            hd.setLeitura(this.getLeitura(i));
            
            for(int j = 0; j < this.getQuantidadeParticoes(i); j++){
                Particao p = new Particao();
                
                p.setDiretorio(this.getNomeParticao(i, j));
                p.setTotal(this.getEspacoTotalParticao(i, j));
                
                if(this.isParticaoValida(p.getDiretorio())){
                    hd.getParticoes().add(p);
                }
            }
            
            listaHD.add(hd);            
        }  
        return listaHD;
        
    }
    
    
  private long getEspacoUsadoParticao(int indexHD, int indexParticao){
      systemInfo = new SystemInfo();
      //return systemInfo.getHardware().getDiskStores()[indexHD].getPartitions()[indexParticao].get
      return 0000000000000;
  }
    
  private int getQuantidadeParticoes(int indexHD){
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getDiskStores()[indexHD].getPartitions().length;
    }
    
    private String[] getIdentificadorHD(){
        systemInfo = new SystemInfo();
        int qntDisco = getQuantidadeDisco();
        String[] serialHD = new String[qntDisco];
        for(int i = 0; i < qntDisco; i++){
            serialHD[i] = systemInfo.getHardware().getDiskStores()[i].getSerial();           
        }
        return serialHD;
        
    }
    
    
    
    /**
     * @return Retorna a quantida de disco
     */
    private int getQuantidadeDisco() {
        systemInfo = new SystemInfo();
        System.out.println("------------------------- "+systemInfo.getHardware().getDiskStores().length);
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
