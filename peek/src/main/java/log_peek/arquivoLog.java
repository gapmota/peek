
package log_peek;

import arquivos.lerArquivo;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;


public class arquivoLog {
public static String nomeArquivo = "-1";
File arquivo;
FileReader fileReader;
BufferedReader bufferedReader;
FileWriter fileWrite;
BufferedWriter bufferedWrite;
    public arquivoLog() 
    
    {
        
    }
    public arquivoLog(String erros) {
        if(nomeArquivo.equals("-1")){
            nomeArquivo = "C://log//log-"+this.getDataAtual().replace("/", "-").replace(" ", "_").replace(":", "-")+".log";
        }
        
        escreverLog("["+this.getDataAtual()+"] "+erros);
    }
    private void escreverLog(String erros){
        
       
    try
    {
        arquivo = new File(nomeArquivo);
        fileReader = new FileReader(arquivo);
        bufferedReader = new BufferedReader(fileReader);
        Vector texto = new Vector();
        while(bufferedReader.ready())
        {
            texto.add(bufferedReader.readLine());
        }
        fileWrite = new FileWriter(arquivo);
        bufferedWrite = new BufferedWriter(fileWrite);
        for(int i=0;i<texto.size();i++)
        {
            bufferedWrite.write(texto.get(i).toString());
            bufferedWrite.newLine();
        }
        bufferedWrite.write(erros);
        bufferedReader.close();
        bufferedWrite.close();
    } 
    catch (FileNotFoundException ex) {
        try 
        {
            arquivo.createNewFile();
        } 
        catch (IOException ex1)
        {
            ex1.printStackTrace();
          System.exit(0); 
        }
    }
       catch(IOException er)
       {
           er.printStackTrace();
           System.exit(0);       }
    }
    
    public String getDataAtual(){
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        return sdf.format(new Date());
    }
    
}
