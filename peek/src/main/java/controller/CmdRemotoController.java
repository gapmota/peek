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

    public void executarComando() {

        CmdRemotoDAO cmdInsert;
        List<CmdRemoto> list = new CmdRemotoDAO().getComandos();
        Scanner in;
        for (CmdRemoto cmd : list) {
            cmdInsert = new CmdRemotoDAO();
            try {
                in = new Scanner(Runtime.getRuntime().exec(cmd.getComando()).getInputStream());
                try {
                    String cmd_retorno = "";
                    while(in.hasNext()){
                         cmd_retorno += in.nextLine()+"\\n";
                    }
                    cmdInsert.insertComandos(new CmdRemoto(cmd.getIdComando(), cmd_retorno));
                    cmdInsert.updateComandosJaExecutado(cmd);
                            
                    System.err.println("AE FOI POURA");
                    
                } catch (SQLException ex) {
                    Logger.getLogger(CmdRemotoController.class.getName()).log(Level.SEVERE, null, ex);
                }
            } catch (IOException ex) {
                Logger.getLogger(ProcessoController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }

    }

}
