
package controller;

import aplicacao.App;
import com.github.seratch.jslack.Slack;
import com.github.seratch.jslack.api.webhook.Payload;
import com.github.seratch.jslack.api.webhook.WebhookResponse;
import model.Processador;
import model.MemoriaRam;
import oshi.SystemInfo;
import controller.ComputadorController;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import model.Computador;


public class NotificacaoController {
 
    Computador c = new Computador();
    
    public void enviarSlack(String texto)
    {
        DateFormat df = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss");
        Date date = new Date();

        String url = "https://hooks.slack.com/services/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";

        Payload payload = Payload.builder()
                .channel("#avisos-peek")
                .username("Integrador")
                .iconEmoji(":smile_cat:")
                .text(texto  + df.format(date))
                .build();

        Slack slack = Slack.getInstance();
        try {
            WebhookResponse response = slack.send(url, payload);
        } catch (IOException ex) {
            Logger.getLogger(App.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    private boolean usoProcessador()
    {
        if(c.getProcessador().getPorcetagemDeUso() > 5) 
        {
            
            new NotificacaoController().enviarSlack("Alto consumo do processador");
            return true;
        }
        else
        {
           return false; 
        }
    }
    
    private boolean usoMemoriaRAM()
    {
        if(c.getRam().getPorcentagemUso() > 5)
        {
            new NotificacaoController().enviarSlack("Alto consumo de RAM");
            return true;
        }
        else
        {
            return false;
        }
    }
}