/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;
import dao.LaboratorioDAO;
import model.Laboratorio;
import java.util.List;
/**
 *
 * @author Aluno
 */
public class LaboratorioController {
    public List<Laboratorio> labs(int idUsuario){
        return new LaboratorioDAO().labs(idUsuario);
    }
}
