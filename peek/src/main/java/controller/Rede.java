package controller;

import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import model.MAC;
import oshi.SystemInfo;
import oshi.hardware.NetworkIF;
import oshi.util.FormatUtil;

public class Rede {

    private SystemInfo systemInfo = null;

    /**
     * @return Retorna a velocidade da rede em bits
     */
    public int getTotalInterfaces() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getNetworkIFs().length;
    }

    public List<MAC> getMacsPC() {
        systemInfo = new SystemInfo();
        int index = systemInfo.getHardware().getNetworkIFs().length;

        List<MAC> macs = new ArrayList<>();

        for (int i = 0; i < index; i++) {
            macs.add(new MAC(systemInfo.getHardware().getNetworkIFs()[i].getMacaddr(),
                    systemInfo.getHardware().getNetworkIFs()[i].getDisplayName()));
        }

        return macs;
    }

    public double getVelocidadeDownload() throws InterruptedException {
        systemInfo = new SystemInfo();

        NetworkIF net = systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()];

        long download1 = net.getBytesRecv();
        long timestamp1 = net.getTimeStamp();
        Thread.sleep(1000); 
        net.updateNetworkStats(); 
        long download2 = net.getBytesRecv();
        long timestamp2 = net.getTimeStamp();
        return ((download2 - download1)/(timestamp2 - timestamp1)) / 125.0;//kb to mbps
        
    }

    public double getVelocidadeUpload() throws InterruptedException {
        systemInfo = new SystemInfo();

        NetworkIF net = systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()];

        long upload1 = net.getBytesSent();
        long timestamp1 = net.getTimeStamp();
        Thread.sleep(1000); 
        net.updateNetworkStats(); 
        long upload2 = net.getBytesSent();
        long timestamp2 = net.getTimeStamp();
        return ((upload2 - upload1)/(timestamp2 - timestamp1)) / 125.0;//kb to mbps
        
    }

    public String getVelocidadeUploadPKG() {
        systemInfo = new SystemInfo();

        systemInfo.getHardware()
                .getNetworkIFs()[getInterfaceEmUso()]
                .updateNetworkStats();

        return FormatUtil.formatBytes(systemInfo.getHardware()
                .getNetworkIFs()[getInterfaceEmUso()]
                .getPacketsSent());
    }

    public long getVelocidadeInterface() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()].getSpeed();
    }

    public String getIPv4() {
        systemInfo = new SystemInfo();
        String[] redes = systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()].getIPv4addr();
        String infos = "";
        for (int i = 0; i < redes.length; i++) {
            infos += redes[i];
        }
        return infos;
    }

    public String getIPv6() {
        systemInfo = new SystemInfo();
        String[] redes = systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()].getIPv6addr();
        String infos = "";
        for (int i = 0; i < redes.length; i++) {
            infos += redes[i];
        }
        return infos;
    }

    public String getMAC() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()].getMacaddr();
    }

    public String getAdaptadorDeRede() {
        systemInfo = new SystemInfo();
        return systemInfo.getHardware().getNetworkIFs()[getInterfaceEmUso()].getDisplayName();
    }

    private int getInterfaceEmUso() {
        systemInfo = new SystemInfo();

        for (int i = 0; i < systemInfo.getHardware().getNetworkIFs().length; i++) {
            if (systemInfo.getHardware().getNetworkIFs()[i].getBytesSent() > 0) {
                return i;
            }
        }

        return -1;
    }
    
    
    public void atualizarDadosRede(){
        systemInfo = new SystemInfo();
        systemInfo.getHardware().getNetworkIFs()[this.getInterfaceEmUso()].updateNetworkStats();
    }
    
    public String getMacParaCadastroInicial(){
        
        for(MAC mac: this.getMacsPC()){
                if(!mac.getAdaptador().toUpperCase().contains("VIRTUAL"))
                return mac.getMac();
        }
        return null;
    }

}
