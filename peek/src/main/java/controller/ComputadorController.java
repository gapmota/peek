package controller;

import java.util.List;

import model.MAC;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;

public class ComputadorController {

    private PreparedStatement ps = null;

    public String cadastroInicial() {

        List<MAC> macs = new Rede().getMacsPC();

        if (!isPcJaCadastrado(macs)) {
            int idComputador = cadastroComputadorInicio();
            boolean cadastrouMac = cadastrarMACS(macs, idComputador);

            return "\n---------------------------------------------------------\n"
                    + "ID_COMPUTADOR: " + idComputador + ""
                    + "\nMAC CADASTRADOS: " + cadastrouMac + ""
                    + "\n---------------------------------------------------------";
        } else {

            return "Computador já cadastro, aguarde...";

        }

    }

    /**
     * METODO PARA DESCOBRIR SE O MAC DO COMPUTADOR JA ESTA CADASTRADO NO BANCO,
     * CASO J� ESTEJA O RETORNO EH TRUE
     *
     * @param mac List<MAC> vem da classe Rede, presenta no package controller.
     * no metodo getMacsPC()
     * @return TRUE = JA TEM PC CADASTRADO COM ESSE MAC | FALSE = NAO TEM
     */
    private boolean isPcJaCadastrado(List<MAC> mac) {
        String SQL = "SELECT * FROM PEEK_MAC_ADDRESS WHERE MAC_ADDRESS = ?";

        for (MAC m : mac) {
            Connection cnx = new Banco().getInstance();

            try {

                cnx.setAutoCommit(true);
                PreparedStatement ps = cnx.prepareStatement(SQL);
                ps.setString(1, m.getMac());

                ResultSet rs = ps.executeQuery();
                if (rs.next()) {
                    // System.out.println(rs);
                    return true;

                }

            } catch (SQLException sqlEx) {
                System.out.print("ERRO SQL0003: ");
                try {
                    if (!cnx.isClosed()) {
                        cnx.rollback();
                    }

                    sqlEx.printStackTrace();
                } catch (SQLException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            } catch (Exception e) {
                System.out.print("ERRO DESC0001: ");
                e.getMessage();
            } finally {
                try {

                    if (!cnx.isClosed()) {

                        cnx.close();

                    }
                } catch (SQLException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }
        }

        return false;// se chegar ate aqui quer dizer que n�o tem o MAC cadastrado
    }

    /**
     * METODO QUE FAZ O PRIMEIRO CADASTRO DE UM COMPUTADOR NA TABELA
     * PEEK_COMPUTADOR
     *
     * @return RETORNA O ID_COMPUTADOR DO COMPUTADOR CADASTRADO
     */
    private int cadastroComputadorInicio() {

        String SQL = "INSERT INTO PEEK_COMPUTADOR(QUANTIDADE_MEMORIA_RAM,DESCRICAO_PROCESSADOR) VALUES (?,?)";
        Connection cnx = new Banco().getInstance();
        int idComputador = -1;
        try {

            Computador computador = new Computador();

            cnx.setAutoCommit(false);
            PreparedStatement ps = cnx.prepareStatement(SQL);

            ps.setString(1, computador.getRam().getTotal());
            ps.setString(2, computador.getProcessador().getNomeProcessador());

            if (ps.executeUpdate() > 0) {
                cnx.commit();
                System.out.println("COMPUTADOR CRIADO");
                idComputador = this.getIdComputador(computador);
                return idComputador;
            }

        } catch (SQLException sqlEx) {
            System.out.print("ERRO SQL0003: ");
            try {
                if (!cnx.isClosed()) {
                    cnx.rollback();
                }

                sqlEx.printStackTrace();
            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        } catch (Exception e) {
            System.out.print("ERRO DESC0001: ");
            e.getMessage();
        } finally {
            try {

                if (!cnx.isClosed()) {

                    cnx.close();

                }

            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        return idComputador;

    }

    /**
     * PEGA O ULTIMO ID_COMPUTADOR CADASTRADO, ESSE METODO SERVE DE COMPLEMENTO
     * PARA O METODO cadastroComputadorInicio()
     *
     * @param computador COMPUTADOR QUE ACABOU DE SER CADASTRADO
     * @return ULTIMO ID_COMPUTADOR CADASTRADO
     */
    private int getIdComputador(Computador computador) {
        String SQL = "SELECT * FROM PEEK_COMPUTADOR WHERE ID_COMPUTADOR = "
                + "(SELECT MAX(ID_COMPUTADOR) FROM PEEK_COMPUTADOR)";
        Connection cnx = new Banco().getInstance();

        try {

            cnx.setAutoCommit(true);
            PreparedStatement ps = cnx.prepareStatement(SQL);

            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                // System.out.println(rs);
                return rs.getInt("ID_COMPUTADOR");

            }

        } catch (SQLException sqlEx) {
            System.out.print("ERRO SQL0003: ");
            try {
                if (!cnx.isClosed()) {
                    cnx.rollback();
                }

                sqlEx.printStackTrace();
            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        } catch (Exception e) {
            System.out.print("ERRO DESC0001: ");
            e.getMessage();
        } finally {
            try {

                if (!cnx.isClosed()) {

                    cnx.close();

                }
            } catch (SQLException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }

        return -1;
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

        String SQL = "INSERT INTO PEEK_MAC_ADDRESS(MAC_ADDRESS,TIPO_CONEXAO,ID_COMPUTADOR) VALUES (?,?,?)";
        int cadastrados = 0;

        for (MAC m : mac) {

            Connection cnx = new Banco().getInstance();
            try {

                cnx.setAutoCommit(false);
                PreparedStatement ps = cnx.prepareStatement(SQL);

                ps.setString(1, m.getMac());
                ps.setString(2, m.getAdaptador());
                ps.setInt(3, idComputador);

                if (ps.executeUpdate() > 0) {
                    cnx.commit();
                    System.out.println(
                            "MAC: " + m.getMac() + "\nADAPTADOR: " + m.getAdaptador() + "\nCADASTRADO COM SUCESSO!");
                    cadastrados++;
                }

            } catch (SQLException sqlEx) {
                System.out.print("ERRO SQL0003: ");
                try {
                    if (!cnx.isClosed()) {
                        cnx.rollback();
                    }

                    sqlEx.printStackTrace();
                } catch (SQLException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            } catch (Exception e) {
                System.out.print("ERRO DESC0001: ");
                e.getMessage();
            } finally {
                try {

                    if (!cnx.isClosed()) {

                        cnx.close();

                    }

                } catch (SQLException e) {
                    // TODO Auto-generated catch block
                    e.printStackTrace();
                }
            }

        }

        return cadastrados == mac.size();

    }

    public void atualizacaoAutomatica() {
        //String processSQL = "EXEC Sp_adicionar_informacoes(?,?,?,?,?,?,?,?,?,?)";
        String SQL = "SELECT * FROM PEEK_COMPUTADOR";

        Connection cnx = new Banco().getInstance();

        try {

            cnx.setAutoCommit(true);
            PreparedStatement ps = cnx.prepareStatement(SQL);

            ResultSet rs = ps.executeQuery();
            System.out.println("Deu bom");

            while (rs.next()) {
                System.out.println(rs.getString(1));
            }

        } catch (SQLException sqlEx) {
            System.out.println("Deu ruim");
        }
    }
}
