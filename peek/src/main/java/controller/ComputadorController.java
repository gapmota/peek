package controller;

import aplicacao.App;
import com.github.seratch.jslack.Slack;
import com.github.seratch.jslack.api.webhook.Payload;
import com.github.seratch.jslack.api.webhook.WebhookResponse;
import model.MAC;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import dao.*;
import java.io.IOException;
import java.sql.SQLException;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ComputadorController {

    ComputadorDAO pcDAO = null;

    public void atualizarHd() {
        pcDAO = new ComputadorDAO();
        try {
            pcDAO.atualizarHd();
        } catch (SQLException ex) {
            Logger.getLogger(ComputadorController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public String cadastroInicial(int idLab) {
        pcDAO = new ComputadorDAO();
        return pcDAO.cadastroInicial(idLab);
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
    private int cadastroComputadorInicio(int idLab) {
        pcDAO = new ComputadorDAO();
        return pcDAO.cadastroComputadorInicio(idLab);

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

    public void coletarInformacoes() {

        new Thread(new Runnable() {
            @Override
            public void run() {
                ComputadorController cc = new ComputadorController();

                while (true) {
                    try {
                        cc.atualizacaoAutomatica();
                        Thread.sleep(10000); //1 minuto
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }

                }
            }
        }).start();

        new Thread(new Runnable() {
            @Override
            public void run() {
                ProcessoController pc = new ProcessoController();

                while (true) {
                    try {
                        System.out.println("comcou");
                        System.out.println(pc.insertProcesso() + " processos inseridos");
                        Thread.sleep(10000); //1 minuto
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }

                }
            }
        }).start();

        new Thread(new Runnable() {
            @Override
            public void run() {
                HDController hd = new HDController();

                while (true) {
                    try {
                        hd.atualizarHd();
                        Thread.sleep(10000); //1 minuto
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }

                }
            }
        }).start();

        new Thread(new Runnable() {
            @Override
            public void run() {
                while (true) {
                    ProcessoController pc = new ProcessoController();
                    pc.deleteProcessosParaFinalizar();
                    try {
                        Thread.sleep(10000);
                    } catch (InterruptedException ex) {
                        Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            }
        }).start();

    }
}
