/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import java.awt.Color;
import java.awt.Font;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;
import javax.swing.JLabel;

/**
 *
 * @author Aluno
 */
public class JanelaModelIniciandoMonitoramento extends JFrame{

    public JanelaModelIniciandoMonitoramento() {
        ij();
        ic();
        this.getContentPane().setBackground(Color.WHITE);
        this.setLocationRelativeTo(null);
        this.setLayout(null);
        this.setVisible(true);   
        
        autoFecharJanela();
    }
    
    
    
    private JLabel txtTexto = null;
    
    public void ij() {
        this.setSize(400,50);        
        this.setUndecorated(true);
    }

    public void ic() {
        txtTexto = new JLabel("iniciando a captura de dados...");
        txtTexto.setBounds(10,10,390,30);
        txtTexto.setFont(new Font("Century Gothic", 0, 15));
        txtTexto.setForeground(Color.BLACK);
        this.add(txtTexto);
       
    }
    
    
    public void autoFecharJanela(){
        int segundos = 0;
        while(segundos < 10){
            try {
                System.out.println(segundos+" ");
                segundos++;
                Thread.sleep(1000);
            } catch (InterruptedException ex) {
                Logger.getLogger(JanelaModelIniciandoMonitoramento.class.getName()).log(Level.SEVERE, null, ex);
            }
            
        }
        this.dispose();
    }
    
}
