/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import oshi.PlatformEnum;
import oshi.SystemInfo;
import oshi.software.os.OSProcess;
import oshi.software.os.OperatingSystem;
import oshi.software.os.OperatingSystemVersion;

/**
 *
 * @author Mateus
 */
public class ProcessoController {

    private SystemInfo systemInfo = null;

    public List<OSProcess> getProcessos() {
        SystemInfo si = new SystemInfo();
        OperatingSystem os = si.getOperatingSystem();

        OSProcess[] processes = os.getProcesses(5000, null);
        List<Integer> pids = new ArrayList<>();
        for (OSProcess p : processes) {
            if (!this.processoDoSistema(p)) {
                pids.add(p.getProcessID());
            }
        }
        // query for just those processes
        Collection<OSProcess> processes1 = os.getProcesses(pids);
        // theres a potential for a race condition here, if a process we queried
        // for initially wasn't running during the second query. In this case,
        // try again with the shorter list

        List<OSProcess> proces = os.getProcesses(pids);
       // proces.sort(Comparator.comparing(OSProcess::getProcessID));
       /*         
            proces.forEach(p -> {
            System.out.println("---------------------------------------------");
            System.out.println("Nome: " + p.getName());
            System.out.println("TimeStart: " + p.getStartTime());
            System.out.println("User: " + p.getUser());
            System.out.println("ProcessID: " + p.getProcessID());
            System.out.println("Path: " + p.getPath());
            System.out.println("Prioridade: " + p.getPriority());
            System.out.println("BytesRead: " + p.getBytesRead());
            System.out.println("BytesWrite: " + p.getBytesWritten());
            System.out.println("UserTime: " + p.getUserTime());
            System.out.println("ResidenteSetSize: " + p.getResidentSetSize());
            System.out.println("CommandLine: " + p.getCommandLine());
            System.out.println("OpenFiles: " + p.getOpenFiles());
            System.out.println("Group: " + p.getGroup());
            System.out.println("GroupID: " + p.getGroupID());
            System.out.println("---------------------------------------------");
        });
        */   
        return proces;
            
    }

    private boolean processoDoSistema(OSProcess processo) {
        
        //if(SystemInfo.getCurrentPlatformEnum().WINDOWS.equals("WINDOWS")){
            
            if (processo.getName().equals("svchost")) 
                return true;

            if(processo.getUser().trim().equals(""))
                return true;

            if(processo.getUser().equals("SISTEMA"))
                return true;

            //if (processo.getPath().contains("C:\\Windows\\System32"))
            //    return true;

            return false;
        
       // }
        
       // return false;
    }

    public void finalizarProcesso(int proc){
        try {
            Runtime.getRuntime().exec("taskkill /PID "+proc);
        } catch (IOException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    
    /**
     * PRECISA TER A EXTENSÃO
     * @param proc 
     */
    public void finalizarProcesso(String proc){
        try {
            Runtime.getRuntime().exec("taskkill /T /F /IM"+proc);
        } catch (IOException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public void selectProcessosParaFinalizar(){
    
    }
    
    public void deleteProcessosParaFinalizar(int proc, String mac){
    
    }
    
    
    
}
