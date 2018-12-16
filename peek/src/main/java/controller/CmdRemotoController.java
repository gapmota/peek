package controller;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

import model.CmdRemoto;
import dao.CmdRemotoDAO;
import java.sql.SQLException;
import java.util.List;
import java.util.Scanner;
import view.JanelaNotificacao;

public class CmdRemotoController {

    CmdRemotoDAO cmdInsert;

    public void executarComando() throws SQLException {

        List<CmdRemoto> list = new CmdRemotoDAO().getComandos();
        Scanner in;

        for (CmdRemoto cmd : list) {
            cmdInsert = new CmdRemotoDAO();
            try {

                if (cmd.getComando().toLowerCase().contains("showalert")) {
                    String[] sp = cmd.getComando().split("~");
                    cmdInsert.insertComandos(new CmdRemoto(cmd.getIdComando(), "apresentada mensagem: " + sp[1]));
                    cmdInsert.updateComandosJaExecutado(cmd);

                    JanelaNotificacao janelaNotificacao = new JanelaNotificacao(sp[1]);
                    
                    return;
                }

                in = new Scanner(Runtime.getRuntime().exec("cmd /c " + cmd.getComando()).getInputStream());
                try {
                    String cmd_retorno = "";

                    if (cmd.getComando().contains("start")) {
                        cmd_retorno = cmd.getComando() + " executado!";
                        cmdInsert.insertComandos(new CmdRemoto(cmd.getIdComando(), cmd_retorno));
                        cmdInsert.updateComandosJaExecutado(cmd);
                        return;
                    }

                    while (in.hasNext()) {
                        cmd_retorno += in.nextLine() + ";";
                    }

                    if (cmd_retorno.equals("")) {
                        cmd_retorno = "comando sem retorno!";
                    }

                    cmd_retorno = cmd_retorno.replace("<", "[").replace(">", "]");
                    cmdInsert.insertComandos(new CmdRemoto(cmd.getIdComando(), cmd_retorno));
                    cmdInsert.updateComandosJaExecutado(cmd);

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
