/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import model.*;
import controller.ProcessoController;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import oshi.SystemInfo;
import oshi.software.os.OSProcess;

/**
 *
 * @author Mateus
 */
public class ProcessoDAO {

    private SystemInfo si = null;

    public List<Processo> selectProcessosParaFinalizar() {
        List<Processo> list = new ArrayList<>();
        int idComputador = new SelectPEEK().getIdComputador();
        String SQL = "SELECT * FROM PEEK_FINALIZAR_PROCESSO WHERE ID_COMPUTADOR = ? AND FLAG_FINALIZAR = 0";
        Connection cnx = new Banco().getInstance();
        Computador computador = new Computador();
        try {

            PreparedStatement ps = cnx.prepareStatement(SQL);
            ps.setInt(1, idComputador);

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                // System.out.println(rs);
                Processo p = new Processo();
                p.setIdProcesso(rs.getInt("ID_FINALIZAR_PROCESSO"));
                p.setPid(rs.getInt("PID"));
                p.setNomeProcesso(rs.getString("NOME_PROCESSO"));
                p.setFlag(rs.getBoolean("FLAG_FINALIZAR"));
                p.setDataCadastro(rs.getString("DATE_TIME"));
                p.setIdComputador(idComputador);

                list.add(p);
            }

        } catch (SQLException sqlEx) {
            System.out.print("ERRO SQL0003: ");
            sqlEx.printStackTrace();
        } catch (Exception e) {
            System.out.print("ERRO DESC0001: ");
            e.getMessage();
        } finally {
            try {

                if (!cnx.isClosed()) {

                    cnx.close();

                }
            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }

        return list;

    }

    
    public int insertProcesso() {
        String SQL = "INSERT INTO PEEK_PROCESSO(NOME,TEMPO_INICIO,USUARIO,PID,CAMINHO,PRIORIDADE,BYTES_LIDOS,BYTES_ESCRITOS, TEMPO_MODO_USUARIO,MEMORIA_RAM_USADA,COMMAND_LINE,OPEN_FILES,GRUPO,GRUPO_ID,ID_COMPUTADOR) "
                + "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        Connection cnx = new Banco().getInstance();
        try {
            cnx.setAutoCommit(false);
        } catch (SQLException ex) {
            Logger.getLogger(ProcessoDAO.class.getName()).log(Level.SEVERE, null, ex);
        }

        int totalRegistros = 0;
        int idComputador = new SelectPEEK().getIdComputador();

        System.out.println("--------APAGANDO ANTERIORES------");
        String SQL2 = "DELETE FROM PEEK_PROCESSO WHERE ID_COMPUTADOR = ?";
        try {
            PreparedStatement ps2 = cnx.prepareStatement(SQL2);
            this.apagarProcessosByIdComputador(ps2, idComputador);
        } catch (SQLException ex) {
            Logger.getLogger(ProcessoDAO.class.getName()).log(Level.SEVERE, null, ex);
        }
        System.out.println("--------APAGANDO ANTERIORES------");

        try {
            List<OSProcess> procs = new ProcessoController().getProcessos();

            for (OSProcess osp : procs) {
                try {

                    PreparedStatement ps = cnx.prepareStatement(SQL);

                    ps.setString(1, osp.getName());
                    ps.setLong(2, osp.getStartTime());
                    ps.setString(3, osp.getUser().length() + "");
                    ps.setInt(4, osp.getProcessID());
                    ps.setString(5, osp.getPath().length() + "");
                    ps.setInt(6, osp.getPriority());
                    ps.setLong(7, osp.getBytesRead());
                    ps.setLong(8, osp.getBytesWritten());
                    ps.setLong(9, osp.getUserTime());
                    ps.setLong(10, osp.getResidentSetSize());
                    ps.setString(11, osp.getCommandLine());
                    ps.setLong(12, osp.getOpenFiles());
                    ps.setString(13, osp.getGroup());
                    ps.setString(14, osp.getGroupID().length() + "");
                    ps.setInt(15, idComputador);

                    totalRegistros += ps.executeUpdate();
                    System.out.println(totalRegistros + " de " + procs.size());

                } catch (SQLException sqlEx) {

                    OSProcess p = osp;

                    System.out.print("ERRO SQL1000: ");
                    sqlEx.printStackTrace();
                    System.out.println("---------------------------------------------");
                    System.out.println("Nome: " + p.getName().length());
                    System.out.println("TimeStart: " + p.getStartTime());
                    System.out.println("Usuario: " + p.getUser().length());
                    System.out.println("PID: " + p.getProcessID());
                    System.out.println("Caminho: " + p.getPath().length());
                    System.out.println("Prioridade: " + p.getPriority());
                    System.out.println("BytesLidos: " + p.getBytesRead());
                    System.out.println("BytesEscritos: " + p.getBytesWritten());
                    System.out.println("TempoModoUsuario: " + p.getUserTime());
                    System.out.println("MemoriaRamUsada: " + p.getResidentSetSize());
                    System.out.println("CommandLine: " + p.getCommandLine());
                    System.out.println("OpenFiles: " + p.getOpenFiles());
                    System.out.println("Group: " + p.getGroup().length());
                    System.out.println("GroupID: " + p.getGroupID().length());
                    System.out.println("---------------------------------------------");
                    break;
                } catch (Exception e) {
                    System.out.print("ERRO DESC1000: ");
                    e.printStackTrace();
                }
            }

            if (totalRegistros == procs.size()) {

                System.out.println("--------COMMITANDO------");
                cnx.commit();
                System.out.println("--------COMMITANDO------");
                cnx.close();
                System.out.println("TOTAL: " + totalRegistros);
            } else {
                System.out.println(totalRegistros + " != " + procs.size());
                
            }

        } catch (SQLException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        } finally {
            try {

                if (!cnx.isClosed()) {

                    cnx.close();

                }

            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        return totalRegistros;
    }

    
    public int deleteProcessosParaFinalizar(Processo processo){
        String SQL = "DELETE FROM PEEK_FINALIZAR_PROCESSO WHERE PID = ? AND ID_COMPUTADOR = ?";
         Connection cnx = new Banco().getInstance();
        try {
            PreparedStatement ps = cnx.prepareStatement(SQL);
            ps.setInt(1, processo.getPid());
            ps.setInt(2, processo.getIdComputador());
            
            return ps.executeUpdate();
            
        } catch (SQLException ex) {
            Logger.getLogger(ProcessoDAO.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        return -1;
    }
    
    private void apagarProcessosByIdComputador(PreparedStatement ps, int idComputador) {
        try {
            ps.setInt(1, idComputador);
            ps.executeUpdate();
            

        } catch (SQLException ex) {
            Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
        }

    }

}
