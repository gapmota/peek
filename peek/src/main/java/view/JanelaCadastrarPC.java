/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import java.awt.Color;
import java.awt.Font;
import javax.swing.JComboBox;
import model.Usuario;
import controller.LaboratorioController;

/**
 *
 * @author Aluno
 */
public class JanelaCadastrarPC extends JanelaPadrao {
    
    private JComboBox jcbListaLaboratorio;    
    private int idUsuario = -1;
    public JanelaCadastrarPC(Usuario usuario) {

        if (usuario == null) {
          //  new JanelaLogin("É preciso estar logado para acessar está tela!");
         //   this.dispose();
        }
        
        idUsuario = usuario.getId();
        
    }

    @Override
    public void ij() {
        this.setTitle("peek - cadastrar máquina");
        this.setResizable(false);
        this.setSize(600, 400);
        this.getContentPane().setBackground(Color.WHITE);
    }

    @Override
    public void ic() {
        jcbListaLaboratorio = new JComboBox();
        jcbListaLaboratorio.setBounds(100,40,350,30);
        this.carregarComboBox(jcbListaLaboratorio);
        jcbListaLaboratorio.setBorder(null);
        jcbListaLaboratorio.setOpaque(true);
        jcbListaLaboratorio.setBackground(Color.WHITE);
        jcbListaLaboratorio.setFont(new Font("Century Gothic", 0, 15));
        jcbListaLaboratorio.setForeground(Color.BLACK);
        jcbListaLaboratorio.setFocusable(false);
        jcbListaLaboratorio.setOpaque(true);
        this.add(jcbListaLaboratorio);
    }
    
    public void carregarComboBox(JComboBox jcb){
        jcb.addItem("-- selecione um laboratório --");
        new LaboratorioController().labs(idUsuario).forEach(lab -> {
            jcb.addItem(lab.getIdLab()+" | "+lab.getNome());
        });
        
    }
    

}
