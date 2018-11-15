/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import oshi.SystemInfo;
import oshi.hardware.HWDiskStore;
import oshi.hardware.HardwareAbstractionLayer;

/**
 *
 * @author Aluno
 */
public class Programa {
    public static void main(String[] args) {
        SystemInfo si = new SystemInfo();
        HardwareAbstractionLayer hw = si.getHardware();
        HWDiskStore[] hd = hw.getDiskStores();
   
        try {
            long tempoAnterior = System.currentTimeMillis();
            long transferAnterior = hd[0].getTransferTime();
            for (int i = 0; i < 100; i++) {
                Thread.sleep(1000);
                hd[0].updateDiskStats();
                long tempoAtual = System.currentTimeMillis();
                long transferAtual = hd[0].getTransferTime();
                int tempoDelta = (int)(tempoAtual - tempoAnterior);
                int transferDelta;
                double perc;
                tempoAnterior = tempoAtual;
                if (transferAtual > transferAnterior) {
                    transferDelta = (int)(transferAtual - transferAnterior);
                    transferAnterior = transferAtual;
                    perc = (100.0 * transferDelta) / tempoDelta;
                } else {
                    perc = 0.0;
                    transferDelta = 0;
                }
                System.out.println(i + " - " + tempoDelta + " / " + transferDelta + " / " + perc);
            }
        } catch (InterruptedException e) {
            
        }
        
        
        
    }
}