/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

/**
 *
 * @author Aluno
 */
public class CmdRemoto {
 
    private int idComando;
    private String comando;

    public int getIdComando() {
        return idComando;
    }

    public void setIdComando(int idComando) {
        this.idComando = idComando;
    }

    public String getComando() {
        return comando;
    }

    public void setComando(String comando) {
        this.comando = comando;
    }

    public CmdRemoto(int idComando, String comando) {
        this.idComando = idComando;
        this.comando = comando;
    }
    
    
    
}
