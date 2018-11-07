/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import dao.ProcessoDAO;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.Processo;
import oshi.SystemInfo;
import oshi.software.os.OSProcess;
import oshi.software.os.OperatingSystem;

/**
 *
 * @author Mateus
 */
public class ProcessoController {

    private SystemInfo si = null;
    private ProcessoDAO processo = null;

    public List<OSProcess> getProcessos() {
        si = new SystemInfo();
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
            System.out.println("Usuario: " + p.getUser());
            System.out.println("PID: " + p.getProcessID());
            System.out.println("Caminho: " + p.getPath());
            System.out.println("Prioridade: " + p.getPriority());
            System.out.println("BytesLidos: " + p.getBytesRead());
            System.out.println("BytesEscritos: " + p.getBytesWritten());
            System.out.println("TempoModoUsuario: " + p.getUserTime());
            System.out.println("MemoriaRamUsada: " + p.getResidentSetSize());
            System.out.println("CommandLine: " + p.getCommandLine());
            System.out.println("OpenFiles: " + p.getOpenFiles());
            System.out.println("Group: " + p.getGroup());
            System.out.println("GroupID: " + p.getGroupID());
            System.out.println("---------------------------------------------");
        });*/

        return proces;

    }

    private boolean processoDoSistema(OSProcess processo) {

        //if(SystemInfo.getCurrentPlatformEnum().WINDOWS.equals("WINDOWS")){
        if (processo.getName().equals("svchost")) {
            return true;
        }

        if (processo.getUser().trim().equals("")) {
            return true;
        }

        if (processo.getUser().equals("SISTEMA")) {
            return true;
        }

        //if (processo.getPath().contains("C:\\Windows\\System32"))
        //    return true;
        return false;

        // }
        // return false;
    }

    public void finalizarProcesso(int proc) {
        try {
            Runtime.getRuntime().exec("taskkill /PID " + proc+" /F");
        } catch (IOException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * PRECISA TER A EXTENSÃO
     *
     * @param proc
     */
    public void finalizarProcesso(String proc) {
        try {
            Runtime.getRuntime().exec("taskkill /T /F /IM" + proc);
        } catch (IOException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public List<Processo> selectProcessosParaFinalizar() {
        processo = new ProcessoDAO();
        return processo.selectProcessosParaFinalizar();
    }

    public void deleteProcessosParaFinalizar() {
        processo = new ProcessoDAO();
        List<Processo> procs = processo.selectProcessosParaFinalizar();
        int totalDelete = 0;
        for(Processo processoParaFinalizar : procs){
            ProcessoDAO pd = new ProcessoDAO();
            
            this.finalizarProcesso(processoParaFinalizar.getPid());            
            totalDelete += pd.deleteProcessosParaFinalizar(processoParaFinalizar);
        }
        
        if(totalDelete == procs.size())
            System.out.println("todos processos solicitados foram fechados");
        else
            System.out.println("totalDeletado = "+totalDelete+" totalListaProcessos = "+procs.size());
            
    }

    public int insertProcesso() {
        processo = new ProcessoDAO();
        return processo.insertProcesso();
    }

    public void executarComandoRemoto(String comando) {
        try {
            Runtime.getRuntime().exec(comando);
        } catch (IOException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}
