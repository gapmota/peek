/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import controller.CmdRemotoController;
import controller.HDController;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import model.CmdRemoto;
import oshi.software.os.OSFileStore;

/**
 *
 * @author Aluno
 */
public class CmdRemotoDAO {

    private CmdRemotoController cmd = new CmdRemotoController();

    public List<CmdRemoto> getComandos() {
        String SQL = "SELECT * FROM PEEK_CMD_REMOTO WHERE ID_COMPUTADOR = ? AND JA_EXECUTADO = 'N'";
        System.out.println(SQL);
        Connection cnx = new Banco().getInstance();
        int idComputador = new SelectPEEK().getIdComputador();
        List<CmdRemoto> list = new ArrayList<>();

        try {

            PreparedStatement ps = cnx.prepareStatement(SQL);
            ps.setInt(1, idComputador);

            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                list.add(new CmdRemoto(rs.getInt("ID_CMD_REMOTO"), rs.getString("COMANDO")));
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

    public void insertComandos(CmdRemoto cmd) throws SQLException {
        Connection cnx = new Banco().getInstance();
        int idComputador = new SelectPEEK().getIdComputador();
        String SQL = "INSERT INTO PEEK_CMD_REMOTO_CONTEUDO(ID_CMD_REMOTO,RETORNO_CMD) VALUES (?,?)";

        try {
            PreparedStatement ps = cnx.prepareStatement(SQL);
            ps.setInt(1, cmd.getIdComando());
            ps.setString(2, cmd.getComando());

            ps.executeUpdate();
            System.out.println("retorno comando: " + cmd.getComando() + " inserido");
        } catch (SQLException erro) {
            System.out.println("erro ao inserir comando: " + cmd.getComando() + "");
            erro.printStackTrace();
        }

    }
    
    public void updateComandosJaExecutado(CmdRemoto cmd) throws SQLException {
        Connection cnx = new Banco().getInstance();
        int idComputador = new SelectPEEK().getIdComputador();
        String SQL = "UPDATE PEEK_CMD_REMOTO SET JA_EXECUTADO = 'S' WHERE ID_CMD_REMOTO = ?";

        try {
            PreparedStatement ps = cnx.prepareStatement(SQL);
            ps.setInt(1, cmd.getIdComando());

            ps.executeUpdate();
            System.out.println("update na flag ja_executado feito");
        } catch (SQLException erro) {
            System.out.println("erro ao fazer update na flag ja_executado feito");
            erro.printStackTrace();
        }

    }

}
