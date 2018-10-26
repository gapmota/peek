package aplicacao;

import controller.*;
import java.util.List;
import model.Particao;

public class App {

    public static void main(String[] args) {

        Computador a = new Computador();
        
        for(int i = 0; i < a.getHD().getInformacoesHdParticao().size(); i++){
            List<Particao> p = a.getHD().getInformacoesHdParticao().get(i).getParticoes();
            
            for(Particao pp : p){
                System.out.println(pp.getDiretorio());
                System.out.println(pp.getTotal());
            }
            
        }
        
        
    }

}
