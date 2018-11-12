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
public class Usuario {
    private String email;
    private String senha;
    private int id;

    public Usuario(String email, String senha) {
        this.email = email;
        this.senha = senha;
    }

    public Usuario() {}
    
    
    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
    
    
    
}
