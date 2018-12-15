/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dao;

import model.Computador;
import dao.Banco;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

/**
 *
 * @author Mateus
 */
public class SelectPEEK {
    
    private static int ID_COMPUTADOR = -1;
    
    public int getIdComputador(){
        if(ID_COMPUTADOR == -1){
            ID_COMPUTADOR = this.getIdComputadorSelect();
        }
        return ID_COMPUTADOR;
    }
    
    
    private int getIdComputadorSelect() {
        String SQL = "SELECT * FROM PEEK_COMPUTADOR WHERE MAC_ADDRESS_INICIAL = ?";
        Connection cnx = new Banco().getInstance();
        Computador computador = new Computador();
        try {

            cnx.setAutoCommit(true);
            PreparedStatement ps = cnx.prepareStatement(SQL);
            ps.setString(1, computador.getRede().getMacParaCadastroInicial());
            
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                // System.out.println(rs);
                return rs.getInt("ID_COMPUTADOR");

            }

        } catch (SQLException sqlEx) {
            System.out.print("ERRO SQL0003: ");
            try {
                if (!cnx.isClosed()) {
                    cnx.rollback();
                }

                sqlEx.printStackTrace();
            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
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

        return -1;
    }
    
}
