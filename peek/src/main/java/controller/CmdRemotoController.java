package controller;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

import model.CmdRemoto;
import dao.CmdRemotoDAO;
import java.sql.SQLException;
import java.util.List;
import java.util.Scanner;

public class CmdRemotoController {
    CmdRemotoDAO cmdInsert;
    public void executarComando() throws SQLException {
        
        List<CmdRemoto> list = new CmdRemotoDAO().getComandos();
        Scanner in;
        
        for (CmdRemoto cmd : list) {
            cmdInsert = new CmdRemotoDAO();
            try {
                in = new Scanner(Runtime.getRuntime().exec("cmd /c "+cmd.getComando()).getInputStream());
                try {
                    String cmd_retorno = "";
                    while(in.hasNext()){
                         cmd_retorno += in.nextLine()+"\\n";
                    }
                    
                    if(cmd_retorno.equals(""))
                        cmd_retorno = "comando sem retorno!";
                    
                    cmdInsert.insertComandos(new CmdRemoto(cmd.getIdComando(), cmd_retorno));
                    cmdInsert.updateComandosJaExecutado(cmd);
                            
                    System.err.println("AE FOI POURA");
                    
                } catch (SQLException ex) {
                    Logger.getLogger(CmdRemotoController.class.getName()).log(Level.SEVERE, null, ex);
                    cmdInsert.updateComandosJaExecutado(cmd);
                }
            } catch (IOException ex) {
                Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
                cmdInsert.updateComandosJaExecutado(cmd);
            }
        }

    }

}
