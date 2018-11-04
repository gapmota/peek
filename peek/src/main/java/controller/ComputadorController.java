package controller;

import model.MAC;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import dao.*;
import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ComputadorController {

    ComputadorDAO pcDAO = null;

    public String atualizarPC() {

        if (this.jaCadastrado()) {
            cadastroInicial();
        }

        atualizacaoAutomatica();
        atualizarHd();
        return "";

    }

    public void atualizarHd() {
        pcDAO = new ComputadorDAO();
        try {
            pcDAO.atualizarHd();
        } catch (SQLException ex) {
            Logger.getLogger(ComputadorController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public String cadastroInicial() {
        pcDAO = new ComputadorDAO();
        return pcDAO.cadastroInicial();
    }

    /**
     * METODO PARA DESCOBRIR SE O MAC DO COMPUTADOR JA ESTA CADASTRADO NO BANCO,
     * CASO J� ESTEJA O RETORNO EH TRUE
     *
     * List <MAC> vem da classe Rede, presenta no package controller. no metodo
     * getMacsPC()
     *
     * @return TRUE = JA TEM PC CADASTRADO COM ESSE MAC | FALSE = NAO TEM
     */
    public boolean jaCadastrado() {
        return isPcJaCadastrado(new RedeController().getMacsPC());
    }

    public boolean isPcJaCadastrado(List<MAC> mac) {
        pcDAO = new ComputadorDAO();
        return pcDAO.isPcJaCadastrado(new RedeController().getMacsPC());// se chegar ate aqui quer dizer que n�o tem o MAC cadastrado

    }

    /**
     * METODO QUE FAZ O PRIMEIRO CADASTRO DE UM COMPUTADOR NA TABELA
     * PEEK_COMPUTADOR
     *
     * @return RETORNA O ID_COMPUTADOR DO COMPUTADOR CADASTRADO
     */
    private int cadastroComputadorInicio() {
        pcDAO = new ComputadorDAO();
        return pcDAO.cadastroComputadorInicio();

    }

    /**
     * PEGA O ULTIMO ID_COMPUTADOR CADASTRADO, ESSE METODO SERVE DE COMPLEMENTO
     * PARA O METODO cadastroComputadorInicio()
     *
     * @param computador COMPUTADOR QUE ACABOU DE SER CADASTRADO
     * @return ULTIMO ID_COMPUTADOR CADASTRADO
     */
    public String getDateTime() {
        DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        Date date = new Date();
        return dateFormat.format(date);
    }

    /**
     * METODO PARA CADASTRAR TODOS OS MAC ADDRESS DO COMPUTADOR
     *
     * @param mac List<MAC> vem da classe Rede, presenta no package controller.
     * no metodo getMacsPC()
     * @param idComputador vem do metodo cadastroComputadorInicio() desta mesma
     * classe
     * @return retorna TRUE se todos mac cadastrarem no banco
     */
    private boolean cadastrarMACS(List<MAC> mac, int idComputador) {
        pcDAO = new ComputadorDAO();
        return pcDAO.cadastrarMACS(mac, idComputador);
    }

    /* ATUALIZAÇÃO DE INFORMAÇÕES DO COMPUTADOR E DA REDE AUTOMÁTICAS
	*
	*   Descrição: O método abaixo é executado repetidas vezes com um intervalo de
	*   5 minutos a cada execução, ele pega as informações do computador, insere na
	*   na procedure e executada a procedura em linguagem SQL;
        *   
        *   As informações necessárias são inseridas na String da procedure e a mesma é
        *   "enviada" para a execução depois da conexão com o banco for iniciada. A query passa
        *   pelo tratamento para verificar se foi realizada e atualizada as informações ou se ocorreu
        *   algum erro.
     */
    public void atualizacaoAutomatica() {
        pcDAO = new ComputadorDAO();
        try {
            pcDAO.atualizacaoAutomatica();
        } catch (SQLException ex) {
            Logger.getLogger(ComputadorController.class.getName()).log(Level.SEVERE, null, ex);
        } catch (InterruptedException ex) {
            Logger.getLogger(ComputadorController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
