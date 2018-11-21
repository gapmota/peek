
package arquivos;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;


public class escreverArquivo {
    
            
            FileWriter fileR;
            BufferedWriter buff;
            

    public escreverArquivo() 
    
    {
                try 
                {
                    fileR = new FileWriter("arquivo.txt");
                    buff = new  BufferedWriter(fileR);
                    buff.write("funciona....");
                    buff.newLine();
                    buff.write("....funcionou");
                    buff.close();
                    
                } 
                catch (IOException ex) {
                    Logger.getLogger(escreverArquivo.class.getName()).log(Level.SEVERE, null, ex);
                }
        
        
    }
    
    
    
}
