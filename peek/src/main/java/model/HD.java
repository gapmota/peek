/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Aluno
 */
public class HD {
    private String identificador;
    private String fabricante;
    private long total;
    private long usado;
    private List<Particao> particoes;
    private long leitura;

    public long getLeitura() {
        return leitura;
    }

    public void setLeitura(long leitura) {
        this.leitura = leitura;
    }
    
    
    
    public HD(){
        particoes = new ArrayList<>();
    }
    
    public String getFabricante() {
        return fabricante;
    }

    public void setFabricante(String fabricante) {
        this.fabricante = fabricante;
    }

    public List<Particao> getParticoes() {
        return particoes;
    }
    
    public String getIdentificador() {
        return identificador;
    }

    public void setIdentificador(String identificador) {
        this.identificador = identificador;
    }

    public long getTotal() {
        return total;
    }

    public void setTotal(long total) {
        this.total = total;
    }

    public long getUsado() {
        return usado;
    }

    public void setUsado(long usado) {
        this.usado = usado;
    }

    @Override
    public String toString() {
        return "HD{" + "identificador=" + identificador + ", fabricante=" + fabricante + ", total=" + total + ", usado=" + usado + '}';
    }

   
    
    
}
