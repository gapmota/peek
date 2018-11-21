
package arquivos;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;


public class lerArquivo {
    
    FileReader fileR;
    BufferedReader buff;
    

    public lerArquivo() 
    {
        
        try 
        {
             
          fileR = new FileReader("arquivo.txt");
          buff = new BufferedReader(fileR);
          
          while(buff.ready())
            {
             System.out.println(buff.readLine());
            }
          buff.close();
        }
         catch (FileNotFoundException ex)
        {
            System.out.println("....erro:  "+ex.getMessage());
        }
        catch(IOException er )
          {
        
          }
    }
    
}
