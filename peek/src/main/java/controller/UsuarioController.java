/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;
import dao.UsuarioDAO;
import model.Usuario;

/**
 *
 * @author Aluno
 */
public class UsuarioController {
    
    public Usuario logar(Usuario user){
        return new UsuarioDAO().logar(user);
    }
    
}
