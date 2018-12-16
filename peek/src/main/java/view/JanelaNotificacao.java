/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import java.awt.Color;
import java.awt.Font;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.plaf.basic.BasicComboBoxRenderer;

/**
 *
 * @author Mateus
 */
public class JanelaNotificacao extends JFrame {

    private JLabel txtAviso = null;
    private String s;

    public JanelaNotificacao(String aviso) {

        this.getContentPane().setBackground(Color.WHITE);

        this.setVisible(true);
        this.setSize(600, 300);
        this.setLocationRelativeTo(null);
        this.setResizable(false);
        this.setTitle("AVISO ENVIADO POR PEEK SYSTEM");
        ij();
        txtAviso.setText("<html><head><meta charset='utf-8'</head><body><pstyle=\"\n"
                + "    padding: 10px;\n"
                + "    overflow: scroll;\n"
                + "\">" + aviso + "</p></body></html>");

    }

    public void ij() {

        txtAviso = new JLabel();
        txtAviso.setBounds(10, 10, 390, 550);
        txtAviso.setFont(new Font("Century Gothic", 0, 15));
        txtAviso.setForeground(Color.BLACK);
        this.add(txtAviso);
    }
}
