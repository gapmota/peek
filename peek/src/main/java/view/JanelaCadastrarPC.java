/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import java.awt.Color;
import model.Usuario;

/**
 *
 * @author Aluno
 */
public class JanelaCadastrarPC extends JanelaPadrao {

    public JanelaCadastrarPC(Usuario usuario) {

        if (usuario == null) {
            new JanelaLogin("É preciso estar logado para acessar está tela!");
            this.dispose();
        }

    }

    @Override
    public void ij() {
        this.setTitle("peek - cadastrar máquina");
        this.setResizable(false);
        this.setSize(400, 600);
        this.getContentPane().setBackground(Color.WHITE);
    }

    @Override
    public void ic() {

    }

}
