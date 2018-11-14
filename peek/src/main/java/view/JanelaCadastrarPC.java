/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import controller.ComputadorController;
import java.awt.Color;
import java.awt.Font;
import javax.swing.JComboBox;
import model.Usuario;
import controller.LaboratorioController;
import java.awt.Cursor;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextArea;

/**
 *
 * @author Aluno
 */
public class JanelaCadastrarPC extends JanelaPadrao implements ActionListener {

    private JLabel lblSecionarLab = null;
    private JComboBox jcbListaLaboratorio;
    private JButton btnCadastrarPc = null;

    public JanelaCadastrarPC(Usuario usuario) {

        if (usuario == null) {
            new JanelaLogin("É preciso estar logado para acessar está tela!");
            this.dispose();
        }

        this.carregarComboBox(jcbListaLaboratorio, usuario.getId());

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

        lblSecionarLab = new JLabel("selecionar laboratório");
        lblSecionarLab.setBounds(25, 25, 200, 30);
        lblSecionarLab.setFont(new Font("Century Gothic", 0, 15));
        lblSecionarLab.setForeground(Color.BLACK);
        this.add(lblSecionarLab);

        jcbListaLaboratorio = new JComboBox();
        jcbListaLaboratorio.setBounds(25, lblSecionarLab.getY() + lblSecionarLab.getHeight() + 7, 550, 30);
        jcbListaLaboratorio.setBorder(null);
        jcbListaLaboratorio.setOpaque(true);
        jcbListaLaboratorio.setBackground(Color.WHITE);
        jcbListaLaboratorio.setFont(new Font("Century Gothic", 0, 15));
        jcbListaLaboratorio.setForeground(Color.BLACK);
        jcbListaLaboratorio.setFocusable(false);
        jcbListaLaboratorio.setOpaque(true);
        this.add(jcbListaLaboratorio);

        btnCadastrarPc = new JButton("cadastrar pc");
        btnCadastrarPc.setBounds(this.getWidth() - 205, this.getHeight() - 80, 180, 30);
        btnCadastrarPc.setFont(new Font("Century Gothic", 0, 15));
        btnCadastrarPc.setForeground(Color.BLACK);
        btnCadastrarPc.setOpaque(true);
        btnCadastrarPc.setBackground(Color.magenta);
        btnCadastrarPc.setBorder(null);
        btnCadastrarPc.setCursor(new Cursor(Cursor.HAND_CURSOR));
        btnCadastrarPc.addActionListener(this);
        this.add(btnCadastrarPc);
    }

    public void carregarComboBox(JComboBox jcb, int idUsuario) {
        jcb.addItem("-- selecione um laboratório --");
        new LaboratorioController().labs(idUsuario).forEach(lab -> {
            jcb.addItem(lab.getIdLab() + " - Laboratório: " + lab.getNome() + " | Andar: " + lab.getAndar());
        });

    }

    @Override
    public void actionPerformed(ActionEvent e) {

        int lab = this.getIdLab();
        if (lab != -1) {
            System.out.println("inicio");
            //JOptionPane.showOptionDialog(this, this, "cadastro de pc", 200, 50, null, null, NORMAL);
            JOptionPane.showMessageDialog(this, new ComputadorController().cadastroInicial(lab));
            System.out.println("fim");
            System.out.println("1111111111111111111111");
        } else {
            JOptionPane.showMessageDialog(this, "selecione um laboratório");
            System.out.println("333333333333333333333333333333333");
        }

    }

    public int getIdLab() {

        if (jcbListaLaboratorio.getSelectedIndex() != 0) {
            String textoCombo = jcbListaLaboratorio.getSelectedItem().toString();
            return Integer.parseInt(textoCombo.split("-")[0].trim());
        } else {
            return -1;
        }

    }

}
