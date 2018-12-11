/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package view;

import controller.UsuarioController;
import java.awt.Color;
import java.awt.Cursor;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import model.Usuario;

/**
 *
 * @author Aluno
 */
public class JanelaLogin extends JanelaPadrao implements ActionListener{

    private JLabel jlEmail, jlSenha;
    private JTextField jtEmail;
    private JPasswordField jpSenha;
    private JButton btnLogar;

    public JanelaLogin(String msgErro) {
        JOptionPane.showMessageDialog(this, msgErro);
    }

    public JanelaLogin() {
        
    }
       
    
    
    @Override
    public void ij() {

        this.setTitle("peek - login");
        this.setResizable(false);
        this.setSize(400, 600);
        this.getContentPane().setBackground(Color.WHITE);

    }

    @Override
    public void ic() {

        jlEmail = new JLabel("E-mail");
        jlEmail.setBounds(25, 150, 350, 30);
        jlEmail.setFont(new Font("Century Gothic", 0, 15));
        jlEmail.setForeground(Color.BLACK);
        this.add(jlEmail);

        jtEmail = new JTextField();
        jtEmail.setBounds(25, jlEmail.getY() + jlEmail.getHeight() + 2, 335, 30);
        jtEmail.setFont(new Font("Century Gothic", 0, 15));
        jtEmail.setForeground(Color.BLACK);
        this.add(jtEmail);

        jlSenha = new JLabel("Senha");
        jlSenha.setBounds(25, jtEmail.getY() + jtEmail.getHeight() + 15, 200, 30);
        jlSenha.setFont(new Font("Century Gothic", 0, 15));
        jlSenha.setForeground(Color.BLACK);
        this.add(jlSenha);

        jpSenha = new JPasswordField();
        jpSenha.setBounds(25, jlSenha.getY() + jlSenha.getHeight() + 2, 335, 30);
        jpSenha.setFont(new Font("Century Gothic", 0, 15));
        jpSenha.setForeground(Color.BLACK);
        this.add(jpSenha);
        
        btnLogar = new JButton("Entrar");
        btnLogar.setBounds(25, jpSenha.getY() + jpSenha.getHeight() + 25, 180, 30);
        btnLogar.setFont(new Font("Century Gothic", 0, 15));
        btnLogar.setForeground(Color.BLACK);
        btnLogar.setOpaque(true);
        btnLogar.setBackground(Color.magenta);
        btnLogar.setBorder(null);
        btnLogar.setCursor(new Cursor(Cursor.HAND_CURSOR));
        btnLogar.addActionListener(this);
        this.add(btnLogar);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        
        if(e.getSource() == btnLogar){
            Usuario user = new Usuario(jtEmail.getText(), jpSenha.getText());
            
            Usuario usuario = new UsuarioController().logar(user);
            
            if(usuario!=null){
                //aqui onde eh acerta LOG AQUI
                new JanelaCadastrarPC(usuario);
                this.dispose();
                
                new log_peek.arquivoLog("logado");
            }else{
                //se errar o login
                JOptionPane.showMessageDialog(this, "usuário ou senha inválido");
                new log_peek.arquivoLog("erro ao tentar se logar");
            }
            
        }
        
    }

}
